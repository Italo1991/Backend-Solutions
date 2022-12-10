namespace Italo.Customer.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepository { get; }
        void Commit();
    }
}
