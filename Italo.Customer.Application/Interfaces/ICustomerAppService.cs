using Italo.Customer.Domain.Entities;

namespace Italo.Customer.Application.Interfaces
{
    public interface ICustomerAppService
    {
        Task<CustomerEntity?> GetByIdAsync(int id);
    }
}
