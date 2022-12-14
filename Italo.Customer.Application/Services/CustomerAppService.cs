using Italo.Customer.Application.Interfaces;
using Italo.Customer.Domain.Interfaces.Repositories;

namespace Italo.Customer.Application.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerAppService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddAsync(Domain.Entities.Customer customer)
        {
            customer.ValidateAndThrow();

            await _unitOfWork.CustomerRepository.AddAsync(customer);
            _unitOfWork.Commit();

            return customer.Id >= 1;
        }

        public void Delete(Domain.Entities.Customer customerEntity)
        {
            _unitOfWork.CustomerRepository.Delete(customerEntity);
            _unitOfWork.Commit();
        }

        public async Task<Domain.Entities.Customer?> GetByIdAsync(int id) 
            => await _unitOfWork.CustomerRepository.GetByIdAsync(id);

        public async Task<bool> AlreadyExists(int id) 
            => await _unitOfWork.CustomerRepository.AlreadyExistsAsync(id);

        public void Modify(int id, Domain.Entities.Customer customer)
        {
            customer.Id = id;
            customer.ValidateAndThrow();

            _unitOfWork.CustomerRepository.Modify(customer);
            _unitOfWork.Commit();
        }
    }
}
