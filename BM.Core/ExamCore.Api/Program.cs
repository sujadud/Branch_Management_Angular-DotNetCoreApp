using ExamCore.Api.Extensions;
using ExamCore.Application.Configurations;
using ExamCore.Shared.Exceptions;
using ExamCore.Shared.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add application services
builder.Services.AddApplicationService();

// Add identity handler services and configure identity services
builder.Services.AddSwaggerExplorer()
    .InjectDbContext(builder.Configuration)
    .AddIdentityHandlersAndStores();

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.ConfigureSwaggerExplorer();
}

// Configuration CORS
app.ConfigureCors(builder.Configuration)
    .AddIdentityAuthMiddlewares();

app.UseHttpsRedirection();

// Use exception handler 
app.UseMiddleware<ExceptionHandlerMiddleware>();

app.MapControllers();

app.Run();