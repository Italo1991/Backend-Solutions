using Italo.Customer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Italo.Customer.Persistence.Configuration
{
    public class AddressConfiguration : BaseEntityConfiguration<Address>
    {
        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            base.Configure(builder);

            builder.ToTable("address");

            builder.HasKey(p => p.Id)
               .HasName("address_id");

            builder.Property(p => p.Id)
                .HasColumnName("address_id")
                .IsRequired();

            builder.Property(p => p.ZipCode)
                .HasColumnName("zipcode")
                .IsRequired();

            builder.Property(p => p.Street)
                .HasColumnName("street")
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Number)
                .HasColumnName("number")
                .IsRequired();

            builder.Property(p => p.Complement)
                .HasColumnName("complement")
                .HasMaxLength(100);

            builder.Property(p => p.City)
                .HasColumnName("city")
                .HasMaxLength(100);

            builder.Property(p => p.State)
                .HasColumnName("state")
                .HasMaxLength(50);

            builder.Property(p => p.Country)
                .HasColumnName("country")
                .HasMaxLength(100);
        }
    }
}
