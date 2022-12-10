using Italo.Customer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Italo.Customer.Persistence.Configuration
{
    public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(p => p.ModificationDate)
                .HasColumnName("modification_date");

            builder.Property(p => p.CreationDate)
                .HasColumnName("creation_date")
                .IsRequired();

            builder.Property(p => p.ModifiedBy)
                .HasColumnName("modified_by");

            builder.Property(p => p.CreatedBy)
                .HasColumnName("created_by")
                .IsRequired();
        }
    }
}
