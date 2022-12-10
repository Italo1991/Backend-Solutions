using Italo.Customer.Domain.Enums;

namespace Italo.Customer.Api.Requests
{
    public class CustomerAddRequest
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public CustomerType CustomerType { get; set; }
    }
}
