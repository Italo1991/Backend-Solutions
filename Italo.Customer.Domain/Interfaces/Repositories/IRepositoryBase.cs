using Italo.Customer.Domain.Entities;

namespace Italo.Customer.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Modify(T entity);
        void Delete(T entity);
        Task<bool> AlreadyExistsAsync(int id);
    }
}
