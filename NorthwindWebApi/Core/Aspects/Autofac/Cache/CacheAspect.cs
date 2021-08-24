using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Cache;
using Core.Utilities.Interceptors.Autofac;
using Core.Utilities.IOC;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Core.Aspects.Autofac.Cache
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        // OrganizationTypeManager.GetByID(1, abc)
        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{ invocation.Method.ReflectedType.FullName }.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(separator:",", values:arguments.Select(x => x?.ToString()?? "<Null>"))})";

            if(_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }

            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration);

        }
    }
}
