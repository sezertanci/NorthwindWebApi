using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors.Autofac
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { } // Method çalışmadan önce çalışır
        protected virtual void OnAfter(IInvocation invocation) { } // Method çalıştıktan sonra çalışır 
        protected virtual void OnExeption(IInvocation invocation) { } // Method hata verdiğinde çalışır 
        protected virtual void OnSuccess(IInvocation invocation) { } // Method başarılıysa çalışır

        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;

            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception)
            {
                isSuccess = false;
                OnExeption(invocation);
                throw;
            }
            finally
            {
                if(isSuccess)
                {
                    OnSuccess(invocation);
                }
            }

            OnAfter(invocation);
        }
    }
}
