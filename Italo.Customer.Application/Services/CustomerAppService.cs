using Italo.Customer.Application.Interfaces;
using Italo.Customer.Domain.Entities;
using Italo.Customer.Domain.Interfaces.Repositories;

namespace Italo.Customer.Application.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerAppService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> AddAsync(CustomerEntity customer)
        {
            customer.ValidateAndThrow();
            customer.CreationDate = DateTime.Now;
            return await _customerRepository.AddAsync(customer) >= 1;
        }

        public async Task<bool> DeleteAsync(CustomerEntity customerEntity) 
            => await _customerRepository.DeleteAsync(customerEntity);

        public async Task<CustomerEntity?> GetByIdAsync(int id) 
            => await _customerRepository.GetByIdAsync(id);

        public async Task<bool> AlreadyExists(int id)
            => await _customerRepository.AlreadyExistsAsync(id);

        public async Task<bool> ModifyAsync(int id, CustomerEntity customer)
        {
            customer.Id = id;
            customer.ModificationDate = DateTime.Now;
            customer.ValidateAndThrow();
            return await _customerRepository.ModifyAsync(customer);
        }
    }
}
