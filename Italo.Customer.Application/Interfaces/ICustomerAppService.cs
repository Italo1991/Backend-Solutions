using Italo.Customer.Domain.Entities;

namespace Italo.Customer.Application.Interfaces
{
    public interface ICustomerAppService
    {
        Task<Domain.Entities.Customer?> GetByIdAsync(int id);
        Task<bool> AddAsync(Domain.Entities.Customer customer);
        void Modify(int id, Domain.Entities.Customer customer);
        void Delete(Domain.Entities.Customer customerEntity);
        Task<bool> AlreadyExists(int id);
    }
}
