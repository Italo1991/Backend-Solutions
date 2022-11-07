using Italo.Customer.Infrastructure.Settings;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Italo.Customer.Api.Extensions
{
    internal static class SwaggerExtension
    {
        internal static void AddSwaggerExtension(this WebApplicationBuilder builder)
        {
            var swaggerSetting = builder.Configuration.GetSection("SwaggerSetting").Get<SwaggerSetting>();

            builder.Services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = swaggerSetting.Title,
                        Version = swaggerSetting.Version,
                        Contact = new OpenApiContact { Email = swaggerSetting.Contact.Email, Name = swaggerSetting.Contact.Name },
                        Description = swaggerSetting.Description
                    });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                opt.IncludeXmlComments(xmlPath);
            });
        }
    }
}
