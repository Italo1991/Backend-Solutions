using Italo.Customer.Domain.Entities;
using Italo.Customer.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Italo.Customer.Persistence.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        private readonly CustomerContext _customerContext;
        public RepositoryBase(CustomerContext customerContext)
        {
            _customerContext = customerContext;
        }

        public async Task<int> AddAsync(T entity)
        {
            _customerContext.Add(entity);
            await _customerContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _customerContext.Remove(entity);
            await _customerContext.SaveChangesAsync();
            return true;
        }

        public async Task<T?> GetByIdAsync(int id)
            => await _customerContext
                    .Set<T>()
                    .Where(p => p.Id == id)
                    .FirstOrDefaultAsync();

        public async Task<bool> AlreadyExistsAsync(int id)
            => await _customerContext
                    .Set<T>()
                    .Where(p => p.Id == id)
                    .AsNoTracking()
                    .FirstOrDefaultAsync() != null;

        public async Task<bool> ModifyAsync(T entity)
        {
            _customerContext.Update(entity);
            await _customerContext.SaveChangesAsync();
            return true;
        }
    }
}
