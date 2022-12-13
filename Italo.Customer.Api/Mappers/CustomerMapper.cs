using AutoMapper;
using Italo.Customer.Api.Requests;
using Italo.Customer.Api.Responses;
using Italo.Customer.Domain.Entities;

namespace Italo.Customer.Api.Mappers
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<Domain.Entities.Customer, CustomerResponse>();
            CreateMap<Address, AddressResponse>();
            CreateMap<Contact, ContactResponse>();

            CreateMap<CustomerRequest, Domain.Entities.Customer>();
            CreateMap<AddressRequest, Address>();
            CreateMap<ContactRequest, Contact>();
        }
    }
}
