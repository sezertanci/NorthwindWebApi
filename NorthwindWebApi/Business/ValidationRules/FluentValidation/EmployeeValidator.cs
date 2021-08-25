using Business.Constants;
using Business.Dto.ViewModel;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class EmployeeValidator : AbstractValidator<EmployeeView>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage(ValidationMessages.NotEmpty).MaximumLength(10).WithMessage(ValidationMessages.MaxLengthExceeded + " - (10)");
            RuleFor(x => x.LastName).NotEmpty().WithMessage(ValidationMessages.NotEmpty).MaximumLength(20).WithMessage(ValidationMessages.MaxLengthExceeded + " - (20)");
            RuleFor(x => x.Title).MaximumLength(30).WithMessage(ValidationMessages.MaxLengthExceeded + " - (30)");
            RuleFor(x => x.TitleOfCourtesy).MaximumLength(25).WithMessage(ValidationMessages.MaxLengthExceeded + " - (25)");
            RuleFor(x => x.Address).MaximumLength(60).WithMessage(ValidationMessages.MaxLengthExceeded + " - (60)");
            RuleFor(x => x.City).MaximumLength(15).WithMessage(ValidationMessages.MaxLengthExceeded + " - (15)");
            RuleFor(x => x.Region).MaximumLength(15).WithMessage(ValidationMessages.MaxLengthExceeded + " - (15)");
            RuleFor(x => x.PostalCode).MaximumLength(10).WithMessage(ValidationMessages.MaxLengthExceeded + " - (10)");
        }
    }
}

