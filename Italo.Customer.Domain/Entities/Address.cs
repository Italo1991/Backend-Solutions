using FluentValidation;
using Italo.Customer.Domain.Validations;

namespace Italo.Customer.Domain.Entities
{
    public class Address : EntityBase
    {
        public int ZipCode { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public override bool Validate() => new AddressValidation().Validate(this).IsValid;

        public override void ValidateAndThrow() => new AddressValidation().ValidateAndThrow(this);
    }
}
