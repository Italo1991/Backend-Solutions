using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Italo.Customer.Persistence.Configuration
{
    public class CustomerConfiguration : BaseEntityConfiguration<Domain.Entities.Customer>
    {
        public override void Configure(EntityTypeBuilder<Domain.Entities.Customer> builder)
        {
            base.Configure(builder);

            builder.ToTable("customer");

            builder.HasKey(p => p.Id)
               .HasName("customer_id");

            builder.Property(p => p.Id)
                .HasColumnName("customer_id")
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

            builder.Property(p => p.AddressId)
                .HasColumnName("address_id")
                .IsRequired();

            builder.HasOne(p => p.Address);
        }
    }
}
