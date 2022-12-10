using Italo.Customer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Italo.Customer.Persistence.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<CustomerEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder.ToTable("customer");

            builder.HasKey(p => p.Id)
                .HasName("id");

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(p => p.Name)
                .HasColumnName("name")
                .HasMaxLength(100);

            builder.Property(p => p.Birthdate)
                .HasColumnName("birthdate")
                .IsRequired();

            builder.Property(p => p.CustomerType)
                .HasColumnName("customer_type")
                .HasColumnType("tinyint")
                .IsRequired();

            builder.Property(p => p.ModificationDate)
                .HasColumnName("modification_date");

            builder.Property(p => p.CreationDate)
                .HasColumnName("creation_date")
                .IsRequired();
        }
    }
}
