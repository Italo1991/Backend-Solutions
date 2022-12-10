using Italo.Customer.Domain.Entities;
using Italo.Customer.Infrastructure.Interfaces;
using Italo.Customer.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Italo.Customer.Persistence
{
    public class CustomerContext : DbContext
    {
        private readonly IUserContext _userContext;

        public DbSet<CustomerEntity> CustomerEntities { get; set; }

        public CustomerContext(DbContextOptions<CustomerContext> options,
            IUserContext userContext) : base(options)
        {
            _userContext = userContext;
        }

        public override int SaveChanges()
        {
            var userName = _userContext.GetUserNameByToken();

            var statesToFilter = new List<EntityState>() { EntityState.Modified, EntityState.Added };
            var entries = base.ChangeTracker.Entries().Where(p => statesToFilter.Contains(p.State));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Modified)
                {
                    ((EntityBase)entry.Entity).ModificationDate = DateTime.Now;
                    ((EntityBase)entry.Entity).ModifiedBy = userName;
                }
                else if (entry.State == EntityState.Added)
                {
                    ((EntityBase)entry.Entity).CreationDate = DateTime.Now;
                    ((EntityBase)entry.Entity).CreatedBy = userName;
                }
            }
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            base.OnModelCreating(modelBuilder); 
        }
    }
}
