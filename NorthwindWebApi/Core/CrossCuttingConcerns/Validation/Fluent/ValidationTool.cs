using FluentValidation;

namespace Core.CrossCuttingConcerns.Validation.Fluent
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, IValidationContext entity)
        {
            var Result = validator.Validate(entity);

            if(!Result.IsValid)
            {
                throw new ValidationException(Result.Errors);
            }
        }
    }
}
