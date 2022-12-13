using Italo.Customer.Domain.Enums;

namespace Italo.Customer.Api.Requests
{
    public class CustomerRequest
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatedBy { get; set; }
        public CustomerType CustomerType { get; set; }
        public AddressRequest Address { get; set; }
    }
}
