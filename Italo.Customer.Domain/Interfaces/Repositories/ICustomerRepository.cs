using Italo.Customer.Domain.Entities;

namespace Italo.Customer.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<CustomerEntity?> GetByIdAsync(int id);
    }
}
