using Business.Constants;
using Business.Dto.ViewModel;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<CustomerView>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage(ValidationMessages.NotEmpty).MaximumLength(5).WithMessage(ValidationMessages.MaxLengthExceeded + " - (5)");
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage(ValidationMessages.NotEmpty).MaximumLength(40).WithMessage(ValidationMessages.MaxLengthExceeded + " - (40)");
            RuleFor(x => x.ContactName).MaximumLength(30).WithMessage(ValidationMessages.MaxLengthExceeded + " - (30)");
            RuleFor(x => x.ContactTitle).MaximumLength(30).WithMessage(ValidationMessages.MaxLengthExceeded + " - (30)");
            RuleFor(x => x.Address).MaximumLength(60).WithMessage(ValidationMessages.MaxLengthExceeded + " - (60)");
            RuleFor(x => x.City).MaximumLength(15).WithMessage(ValidationMessages.MaxLengthExceeded + " - (15)");
            RuleFor(x => x.Region).MaximumLength(15).WithMessage(ValidationMessages.MaxLengthExceeded + " - (15)");
            RuleFor(x => x.PostalCode).MaximumLength(10).WithMessage(ValidationMessages.MaxLengthExceeded + " - (10)");
            RuleFor(x => x.Country).MaximumLength(15).WithMessage(ValidationMessages.MaxLengthExceeded + " - (15)");
            RuleFor(x => x.Phone).MaximumLength(24).WithMessage(ValidationMessages.MaxLengthExceeded + " - (24)");
            RuleFor(x => x.Fax).MaximumLength(24).WithMessage(ValidationMessages.MaxLengthExceeded + " - (24)");
        }
    }
}

