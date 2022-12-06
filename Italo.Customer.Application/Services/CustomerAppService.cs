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

        public async Task<CustomerEntity?> GetByIdAsync(int id) 
            => await _customerRepository.GetByIdAsync(id);
    }
}
