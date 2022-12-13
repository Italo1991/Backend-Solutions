using Italo.Customer.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Italo.Customer.Persistence.Repositories
{
    public class CustomerRepository : RepositoryBase<Domain.Entities.Customer>, IRepositoryBase<Domain.Entities.Customer>, ICustomerRepository
    {
        public CustomerRepository(CustomerContext customerContext) 
            : base(customerContext) { }

        public override async Task<Domain.Entities.Customer?> GetByIdAsync(int id)
            => await _customerContext
                    .Set<Domain.Entities.Customer>()
                    .Where(p => p.Id == id)
                    .Include(p => p.Address)
                    .Include(p => p.Contacts)
                    .FirstOrDefaultAsync();
    }
}
