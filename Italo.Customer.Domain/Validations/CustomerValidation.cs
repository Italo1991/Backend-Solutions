using FluentValidation;
using Italo.Customer.Domain.Entities;

namespace Italo.Customer.Domain.Validations
{
    public class CustomerValidation : AbstractValidator<CustomerEntity>
    {
        public CustomerValidation()
        {
            RuleFor(p => p.Id)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Id is invalid");

            RuleFor(p => p.Name)
                .NotEmpty()
                .MaximumLength(100)
                .MinimumLength(5)
                .WithMessage("Name is invalid");

            RuleFor(p => p.Birthdate)
                .GreaterThan(DateTime.MinValue)
                .LessThan(DateTime.Now.AddYears(-18))
                .WithMessage("Birthdate is invalid");

            RuleFor(p => (int)p.CustomerType)
                .GreaterThan(0)
                .LessThanOrEqualTo(2)
                .NotEmpty()
                .WithMessage("Customer type invalid");
        }
    }
}
