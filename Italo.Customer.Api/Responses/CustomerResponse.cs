using Italo.Customer.Domain.Enums;

namespace Italo.Customer.Api.Responses
{
    public class CustomerResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public CustomerType CustomerType { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
