using Italo.Customer.Domain.Interfaces.Repositories;
using Italo.Customer.Persistence.Repositories;

namespace Italo.Customer.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CustomerContext context;
        private ICustomerRepository _customerRepository;

        public UnitOfWork(CustomerContext customerContext) 
            => context = customerContext;

        public ICustomerRepository CustomerRepository
        {
            get
            {
                return _customerRepository = _customerRepository ?? new CustomerRepository(context);
            }
        }

        public void Commit() => context.SaveChanges();
        public void Dispose() => context.Dispose();
    }
}
