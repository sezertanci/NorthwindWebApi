using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Cache;
using Core.Utilities.Interceptors.Autofac;
using Core.Utilities.IOC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Cache
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }

    }
}
