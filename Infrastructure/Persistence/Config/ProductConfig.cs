using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SouvenirShop.Domain.Entities;

namespace Infrastructure.Persistence.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name)
                .IsUnicode()
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Quantity)
                .IsRequired();

            builder.Property(p => p.Description)
                .IsRequired()
                .IsUnicode();

            builder.Property(p => p.ImageUrl)
                .IsUnicode();

            builder.Property(d => d.SellingPrice)
                .IsRequired();

            builder.HasOne(p => p.SubCategory)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SubCategoryId);
        }
    }
}