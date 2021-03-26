using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SouvenirShop.Domain.Entities;

namespace Infrastructure.Persistence.Config
{
    public class SupplierConfig : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.Property(s => s.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);

            builder.Property(s => s.Address)
                .IsUnicode()
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}