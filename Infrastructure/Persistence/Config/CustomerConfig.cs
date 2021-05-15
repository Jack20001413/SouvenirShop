using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SouvenirShop.Domain.Entities;

namespace Infrastructure.Persistence.Config
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode();

            builder.Property(c => c.IsValid)
                .IsRequired();

            builder.Property(c => c.Email)
                .IsRequired();

            builder.Property(c => c.Password)
                .IsRequired();

            builder.Property(c => c.Address)
                .IsRequired();

            builder.Property(c => c.Phone)
                .IsRequired();

            builder.Property(c => c.BirthDate)
                .IsRequired();
        }
    }
}