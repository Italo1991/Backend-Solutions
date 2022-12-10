using Italo.Customer.Domain.Entities;

namespace Italo.Customer.Application.Interfaces
{
    public interface ICustomerAppService
    {
        Task<CustomerEntity?> GetByIdAsync(int id);
        Task<bool> AddAsync(CustomerEntity customer);
        Task<bool> ModifyAsync(int id, CustomerEntity customer);
        Task<bool> DeleteAsync(CustomerEntity customerEntity);
        Task<bool> AlreadyExists(int id);
    }
}
