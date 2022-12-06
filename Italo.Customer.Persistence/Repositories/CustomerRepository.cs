using Italo.Customer.Domain.Entities;
using Italo.Customer.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Italo.Customer.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _customerContext;
        public CustomerRepository(CustomerContext customerContext)
        {
            _customerContext = customerContext;
        }

        public async Task<CustomerEntity?> GetByIdAsync(int id) 
            => await _customerContext.Set<CustomerEntity>().Where(p => p.Id == id).FirstOrDefaultAsync();
    }
}
