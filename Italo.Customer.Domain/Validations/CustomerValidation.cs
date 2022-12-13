using FluentValidation;

namespace Italo.Customer.Domain.Validations
{
    public class CustomerValidation : AbstractValidator<Entities.Customer>
    {
        public CustomerValidation()
        {
            RuleFor(p => p.Id)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Id invalid");

            RuleFor(p => p.Name)
                .NotEmpty()
                .MaximumLength(100)
                .MinimumLength(5)
                .WithMessage("Name invalid");

            RuleFor(p => p.Birthdate)
                .GreaterThan(DateTime.MinValue)
                .LessThan(DateTime.Now.AddYears(-18))
                .WithMessage("Birthdate invalid");

            RuleFor(p => (int)p.CustomerType)
                .GreaterThan(0)
                .LessThanOrEqualTo(2)
                .NotEmpty()
                .WithMessage("Customer type invalid");

            RuleFor(p => p.Address)
                .SetValidator(new AddressValidation());
        }
    }
}
