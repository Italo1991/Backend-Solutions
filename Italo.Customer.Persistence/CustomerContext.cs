using Italo.Customer.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Italo.Customer.Persistence
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            base.OnModelCreating(modelBuilder); 
        }
    }
}
