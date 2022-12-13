using Italo.Customer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Italo.Customer.Persistence.Configuration
{
    public class ContactConfiguration : BaseEntityConfiguration<Contact>
    {
        public override void Configure(EntityTypeBuilder<Contact> builder)
        {
            base.Configure(builder);

            builder.ToTable("contact");

            builder.HasKey(p => p.Id)
               .HasName("contact_id");

            builder.Property(p => p.Id)
                .HasColumnName("contact_id")
                .IsRequired();

            builder.Property(p => p.CustomerId)
                .HasColumnName("customer_id")
                .IsRequired();

            builder.Property(p => p.PhoneNumber)
                .HasColumnName("phonenumber")
                .HasMaxLength(30)
                .IsRequired();

            builder.HasOne(p => p.Customer)
                .WithMany(p => p.Contacts)
                .HasForeignKey(p => p.CustomerId);
        }
    }
}
