using FluentValidation;
using Italo.Customer.Domain.Entities;

namespace Italo.Customer.Domain.Validations
{
    public class AddressValidation : AbstractValidator<Address>
    {
        public AddressValidation()
        {
            RuleFor(p => p.ZipCode)
                .LessThanOrEqualTo(999999)
                .NotEmpty()
                .WithMessage("Zipcode invalid");

            RuleFor(p => p.Street)
                .NotEmpty()
                .NotNull()
                .MaximumLength(200)
                .WithMessage("Street invalid");

            RuleFor(p => p.Number)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithMessage("Number invalid");

            RuleFor(p => p.Complement)
                .MaximumLength(100)
                .WithMessage("Complement invalid");

            RuleFor(p => p.City)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100)
                .WithMessage("City invalid");

            RuleFor(p => p.State)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50)
                .WithMessage("State invalid");

            RuleFor(p => p.Country)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100)
                .WithMessage("Country invalid");
        }
    }
}
