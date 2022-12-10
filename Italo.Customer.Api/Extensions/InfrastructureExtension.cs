using Italo.Customer.Infrastructure.Interfaces;
using Italo.Customer.Infrastructure.Security;

namespace Italo.Customer.Api.Extensions
{
    public static class InfrastructureExtension
    {
        public static void AddInfrastructure(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped<IUserContext, UserContext>();
        }
    }
}
