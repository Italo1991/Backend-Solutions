using Italo.Customer.Api.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.AddDatabaseExtension();
builder.AddAuthenticationJwtExtension();
builder.AddLogExtension();
builder.AddSwaggerExtension();
builder.AddApplicationServicesExtension();
builder.AddRepositoriesExtension();
builder.AddInfrastructureExtension();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
//app.UseAllElasticApm(builder.Configuration);

app.Run();
