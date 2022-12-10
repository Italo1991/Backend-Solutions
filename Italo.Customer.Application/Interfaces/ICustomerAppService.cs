using Italo.Customer.Domain.Entities;

namespace Italo.Customer.Application.Interfaces
{
    public interface ICustomerAppService
    {
        Task<CustomerEntity?> GetByIdAsync(int id);
        Task<bool> AddAsync(CustomerEntity customer);
        void Modify(int id, CustomerEntity customer);
        void Delete(CustomerEntity customerEntity);
        Task<bool> AlreadyExists(int id);
    }
}
