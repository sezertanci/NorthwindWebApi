using Core.Utilities.IOC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection services, ICoreModule[] modules)
        {
            foreach(var item_module in modules)
            {
                item_module.Load(services);
            }

            return ServiceTool.Create(services);
        }
    }
}
