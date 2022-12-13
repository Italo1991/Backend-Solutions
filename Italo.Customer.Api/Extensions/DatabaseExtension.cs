using Italo.Customer.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Italo.Customer.Api.Extensions
{
    public static class DatabaseExtension
    {
        public static void AddDatabaseExtension(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<CustomerContext>(
                p => p.UseSqlServer(builder.Configuration["ConnectionString:SqlServer"]),
                ServiceLifetime.Scoped);
        }
    }
}
