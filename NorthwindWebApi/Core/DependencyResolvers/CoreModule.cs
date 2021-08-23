using Core.Utilities.IOC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            //services.AddSingleton<ICacheManager, MemoryCacheManager>();
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}