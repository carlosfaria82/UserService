using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using UserService.HostApi.LoggerService;

namespace UserService.HostApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConfigurationApplication(this IServiceCollection services)
        {
            var namespacePrefix = $"{nameof(UserService)}";

            var applicationAsembly = Assembly.Load(new AssemblyName($"{namespacePrefix}.{nameof(Application)}"));
            var dataAsembly = Assembly.Load(new AssemblyName($"{namespacePrefix}.{nameof(Data)}"));
            var domainAsembly = Assembly.Load(new AssemblyName($"{namespacePrefix}.{nameof(Domain)}"));

            return services
                .AddSingleton<ILoggerManager, LoggerManager>()
                .Scan(typeSourceSelector => typeSourceSelector
                    .FromAssemblies(applicationAsembly, dataAsembly, domainAsembly)
                        .AddClasses()
                            .AsMatchingInterface()
                            .WithScopedLifetime());
        }
    }
}
