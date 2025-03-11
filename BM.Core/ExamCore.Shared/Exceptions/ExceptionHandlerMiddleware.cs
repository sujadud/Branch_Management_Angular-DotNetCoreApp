using ExamCore.Shared.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;

namespace ExamCore.Shared.Exceptions
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        // Only inject the necessary services (RequestDelegate and ILogger)
        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // _next is already the correct RequestDelegate passed by the framework
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
                var name = typeof(ExceptionHandlerMiddleware).Name;
                _logger.LogError($"Error on : {name}", ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            var errorCode = 500;
            var result = string.Empty;
            var response = new ResponseMessage<string>();

            switch (exception)
            {
                case ValidationException validationException:
                    statusCode = HttpStatusCode.OK;
                    errorCode = 422;
                    result = JsonConvert.SerializeObject(validationException.Failures);
                    break;

                case BadRequestException badRequestException:
                    statusCode = HttpStatusCode.OK;
                    errorCode = 400;
                    result = badRequestException.Message;
                    break;

                case NotFoundException notFoundException:
                    statusCode = HttpStatusCode.OK;
                    errorCode = 404;
                    result = notFoundException.Message;
                    break;

                case UnAuthorizedException unAuthorized:
                    statusCode = HttpStatusCode.Unauthorized;
                    result = unAuthorized.Message;
                    errorCode = 401;
                    break;

                case DeleteFailureException deleteFailureException:
                    statusCode = HttpStatusCode.Forbidden;
                    errorCode = 403;
                    result = deleteFailureException.Message;
                    break;
            }

            if (exception.Message.Contains("foreign key is not nullable"))
            {
                statusCode = (HttpStatusCode)547;
                result = "The record cannot be deleted because it is associated with another record.";
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            response.ErrorMessage = result != string.Empty ? result : exception.Message;
            response.StatusCode = (int)statusCode;
            response.ErrorCode = errorCode;
            response.MessageType = MessageType.Error;

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }));
        }
    }

    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            // Simply add the middleware to the pipeline
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}