using Italo.Customer.Domain.Entities;

namespace Italo.Customer.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        Task<T?> GetByIdAsync(int id);
        Task<int> AddAsync(T entity);
        Task<bool> ModifyAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<bool> AlreadyExistsAsync(int id);
    }
}
