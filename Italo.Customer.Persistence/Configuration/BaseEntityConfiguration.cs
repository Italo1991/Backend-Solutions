using Italo.Customer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Italo.Customer.Persistence.Configuration
{
    public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(p => p.Id)
               .HasName("id");

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(p => p.ModificationDate)
                .HasColumnName("modification_date");

            builder.Property(p => p.CreationDate)
                .HasColumnName("creation_date")
                .IsRequired();

            builder.Property(p => p.ModifiedBy)
                .HasColumnName("modified_by")
                .HasMaxLength(100);

            builder.Property(p => p.CreatedBy)
                .HasColumnName("created_by")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
