using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation.Fluent;
using Core.Utilities.Interceptors.Autofac;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;

        public ValidationAspect(Type validatorType)
        {
            if(!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception("Yanlış validasyon tipi");
            }

            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; // Objeye ulaşmak
            var entities = (IEnumerable<IValidationContext>)invocation.Arguments.Where(x => x.GetType() == entityType);

            foreach(var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
