using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Core.Utilities.Interceptors.Autofac
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(inherit: true).ToList();

            var methods = type.GetMethods().Where(x => x.Name == method.Name);

            List<IEnumerable<MethodInterceptionBaseAttribute>> array = new List<IEnumerable<MethodInterceptionBaseAttribute>>();

            foreach(var item in methods)
            {
                array.Add(item.GetCustomAttributes<MethodInterceptionBaseAttribute>(inherit: true));
            }

            foreach(var item in array)
            {
                classAttributes.AddRange(item);
            }

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
