using Serilog;

namespace Italo.Customer.Api.Extensions
{
    internal static class LogExtension
    {
        internal static void AddLogExtensions(this WebApplicationBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
              .MinimumLevel.Debug()
              .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
              .CreateBootstrapLogger();

            builder.Host.UseSerilog();
        }
    }
}
