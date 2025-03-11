using Microsoft.OpenApi.Models;

namespace ExamCore.Api.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerExplorer(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            // Register the Swagger generator
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "DSL ERP Solution", Version = "v1" });

                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Please, file in the JWT token"
                });

                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new List<String>()
                    }
                });
            });

            services.AddCors(option =>
            {
                option.AddPolicy("AllowOrigin", policy =>
                {
                    policy.AllowAnyOrigin();
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                });
            });

            return services;
        }

        public static WebApplication ConfigureSwaggerExplorer(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DSL ERP Solution V1");
                c.DefaultModelsExpandDepth(2); // Set the default depth for expanding models
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None); // Change default expansion to uncollapsed
            });

            return app;
        }
    }
}