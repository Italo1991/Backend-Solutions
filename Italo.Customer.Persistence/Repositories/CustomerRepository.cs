using Italo.Customer.Domain.Entities;
using Italo.Customer.Domain.Interfaces.Repositories;

namespace Italo.Customer.Persistence.Repositories
{
    public class CustomerRepository : RepositoryBase<CustomerEntity>, IRepositoryBase<CustomerEntity>, ICustomerRepository
    {
        public CustomerRepository(CustomerContext customerContext) 
            : base(customerContext) { }
    }
}
