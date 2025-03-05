using AutoMapper;
using ExamCore.Shared.Mappings;
using System.Reflection;

namespace ExamCore.Application.Configurations
{
    public class AutomapperMappingProfile : Profile
    {
        public AutomapperMappingProfile()
        {
            // Add the mappings from all types that implement IMapFrom<T> interface
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}