using Business.Constants;
using Business.Dto.ViewModel;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<ProductView>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage(ValidationMessages.NotEmpty).MaximumLength(15).WithMessage(ValidationMessages.MaxLengthExceeded);
        }
    }
}
