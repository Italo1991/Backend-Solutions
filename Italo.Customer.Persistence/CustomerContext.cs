using Italo.Customer.Domain.Entities;
using Italo.Customer.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Italo.Customer.Persistence
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var statesToFilter = new List<EntityState>() { EntityState.Modified, EntityState.Added };
            var entries = base.ChangeTracker.Entries().Where(p => statesToFilter.Contains(p.State));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Modified)
                {
                    ((EntityBase)entry.Entity).ModificationDate = DateTime.Now;
                }
                else if (entry.State == EntityState.Added)
                    ((EntityBase)entry.Entity).CreationDate = DateTime.Now;
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            base.OnModelCreating(modelBuilder); 
        }
    }
}
