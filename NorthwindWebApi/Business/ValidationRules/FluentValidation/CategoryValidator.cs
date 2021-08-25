using Business.Constants;
using Business.Dto.ViewModel;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<CategoryView>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage(ValidationMessages.NotEmpty).MaximumLength(15).WithMessage(ValidationMessages.MaxLengthExceeded + " - (15)");
        }
    }
}

