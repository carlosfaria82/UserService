using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
                .Scan(typeSourceSelector => typeSourceSelector
                    .FromAssemblies(applicationAsembly, dataAsembly, domainAsembly)
                        .AddClasses()
                            .AsMatchingInterface()
                            );
        }
    }
}
