using FluentValidation;
using Italo.Customer.Domain.Validations;

namespace Italo.Customer.Domain.Entities
{
    public class Contact : EntityBase
    {
        public string PhoneNumber { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public override bool Validate() => new ContactValidation().Validate(this).IsValid;
        public override void ValidateAndThrow() => new ContactValidation().ValidateAndThrow(this);
    }
}
