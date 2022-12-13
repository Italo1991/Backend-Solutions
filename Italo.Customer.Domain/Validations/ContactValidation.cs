using FluentValidation;
using Italo.Customer.Domain.Entities;

namespace Italo.Customer.Domain.Validations
{
    public class ContactValidation : AbstractValidator<Contact>
    {
        public ContactValidation()
        {
            RuleFor(p => p.PhoneNumber)
                .NotEmpty()
                .NotNull()
                .MaximumLength(30)
                .WithMessage("Phonenumber invalid");
        }
    }
}
