using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SouvenirShop.Domain.Entities;

namespace Infrastructure.Persistence.Config
{
    public class ProductDetailConfig : IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {
            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode();

            builder.Property(d => d.Quantity)
                .IsRequired();

            builder.Property(d => d.SellingPrice)
                .IsRequired();

            builder.Property(d => d.ImportingPrice)
                .IsRequired();

            builder.HasOne(d => d.Size)
                .WithMany(s => s.ProductDetails)
                .HasForeignKey(d => d.SizeId);

            builder.HasOne(d => d.Product)
                .WithMany(p => p.ProductDetails)
                .HasForeignKey(d => d.ProductId);

            builder.HasOne(d => d.Color)
                .WithMany(c => c.ProductDetails)
                .HasForeignKey(d => d.ColorId);
        }
    }
}