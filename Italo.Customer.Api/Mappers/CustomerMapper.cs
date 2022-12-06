﻿using AutoMapper;
using Italo.Customer.Api.Responses;
using Italo.Customer.Domain.Entities;

namespace Italo.Customer.Api.Mappers
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<CustomerEntity, CustomerResponse>();
        }
    }
}