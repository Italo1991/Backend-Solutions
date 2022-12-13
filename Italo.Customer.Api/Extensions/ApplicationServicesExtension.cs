using Italo.Customer.Application.Interfaces;
using Italo.Customer.Application.Services;

namespace Italo.Customer.Api.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static void AddApplicationServicesExtension(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ICustomerAppService, CustomerAppService>();
        }
    }
}
