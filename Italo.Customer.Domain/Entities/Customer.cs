using FluentValidation;
using Italo.Customer.Domain.Enums;
using Italo.Customer.Domain.Validations;

namespace Italo.Customer.Domain.Entities
{
    public class Customer : EntityBase
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public CustomerType CustomerType { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }

        public override bool Validate() => new CustomerValidation().Validate(this).IsValid;

        public override void ValidateAndThrow() => new CustomerValidation().ValidateAndThrow(this);
    }
}
