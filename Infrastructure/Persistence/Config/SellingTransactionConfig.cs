using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SouvenirShop.Domain.Entities;

namespace Infrastructure.Persistence.Config
{
    public class SellingTransactionConfig : IEntityTypeConfiguration<SellingTransaction>
    {
        public void Configure(EntityTypeBuilder<SellingTransaction> builder)
        {
            builder.Property(t => t.Quantity)
                .IsRequired();

            builder.Property(t => t.Price)
                .IsRequired();

            builder.HasOne(t => t.ProductDetail)
                .WithMany(d => d.SellingTransactions)
                .HasForeignKey(t => t.ProductDetailId);

            builder.HasOne(t => t.SellingOrder)
                .WithMany(o => o.SellingTransactions)
                .HasForeignKey(t => t.SellingOrderId);
        }
    }
}