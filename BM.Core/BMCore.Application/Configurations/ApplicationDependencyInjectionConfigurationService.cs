using BMCore.Manager.Contracts;
using BMCore.Manager.Manager;
using BMCore.Model.Models;
using BMCore.Repository.Base;
using BMCore.Repository.Contracts;
using BMCore.Repository.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BMCore.Application.Configurations
{
    public static class ApplicationDependencyInjectionConfigurationService
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            // Add automapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<AutomapperMappingProfile>();
            }, Assembly.GetExecutingAssembly());

            // Add mediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            // Register IHttpContextAccessor 
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            #region Add Manager and Repository Services
            //services.AddScoped(typeof(IBaseManager<>), typeof(BaseManager<>));
            //services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICountryManager, CountryManager>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IBranchManager, BranchManager>();
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<IEmployeeManager, EmployeeManager>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ICityManager, CityManager>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IRoleManager, RoleManager>();
            services.AddScoped<IRoleRepository, RoleRepository>();

            #endregion

            return services;
        }
    }
}