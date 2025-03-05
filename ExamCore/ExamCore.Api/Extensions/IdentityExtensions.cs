using ExamCore.Database.DatabaseContexts;
using ExamCore.Model.Models;

namespace ExamCore.Api.Extensions
{
    public static class IdentityExtensions
    {
        public static IServiceCollection AddIdentityHandlersAndStores(this IServiceCollection services)
        {
            // Add identity services
            services.AddIdentityApiEndpoints<User>()
                .AddEntityFrameworkStores<DatabaseContext>();

            return services;
        }

        public static WebApplication AddIdentityAuthMiddlewares(this WebApplication app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors();

            return app;
        }
    }
}