using Serilog;
using Serilog.Events;
using Serilog.Exceptions;

namespace Italo.Customer.Api.Extensions
{
    internal static class LogExtension
    {
        internal static void AddLogExtension(this WebApplicationBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails()
                .Enrich.WithCorrelationId()
                .Enrich.WithProperty("ApplicationName", $"API Serilog - {Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")}")
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            builder.Host.UseSerilog(Log.Logger);
        }
    }
}
