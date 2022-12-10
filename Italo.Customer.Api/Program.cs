using Italo.Customer.Api.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.AddDatabase();
builder.AddAuthenticationJwt();
builder.AddLogExtensions();
builder.AddSwagger();
builder.AddApplicationServices();
builder.AddRepositories();
builder.AddInfrastructure();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
//app.UseAllElasticApm(builder.Configuration);

app.Run();
