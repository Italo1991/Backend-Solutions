using Italo.Customer.Domain.Interfaces.Repositories;
using Italo.Customer.Persistence.Repositories;

namespace Italo.Customer.Api.Extensions
{
    public static class RepositoriesExtension
    {
        public static void AddRepositories(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}
