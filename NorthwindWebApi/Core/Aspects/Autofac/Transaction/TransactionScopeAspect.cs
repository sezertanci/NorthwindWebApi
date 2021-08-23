using Castle.DynamicProxy;
using Core.Utilities.Interceptors.Autofac;
using System;
using System.Transactions;

namespace Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using(TransactionScope NewTransactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    NewTransactionScope.Complete();
                }
                catch(Exception)
                {
                    NewTransactionScope.Dispose();
                    throw;
                }
            }
        }
    }
}
