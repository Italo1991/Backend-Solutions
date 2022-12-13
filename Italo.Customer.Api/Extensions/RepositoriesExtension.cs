using Italo.Customer.Domain.Interfaces.Repositories;
using Italo.Customer.Persistence;
using Italo.Customer.Persistence.Repositories;

namespace Italo.Customer.Api.Extensions
{
    public static class RepositoriesExtension
    {
        public static void AddRepositoriesExtension(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
