using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SouvenirShop.Domain.Entities;

namespace Infrastructure.Persistence.Config
{
    public class ImportingTransactionConfig : IEntityTypeConfiguration<ImportingTransaction>
    {
        public void Configure(EntityTypeBuilder<ImportingTransaction> builder)
        {
            builder.Property(t => t.Price)
                .IsRequired();

            builder.Property(t => t.Quantity)
                .IsRequired();

            builder.HasOne(t => t.ProductDetail)
                .WithMany(d => d.ImportingTransactions)
                .HasForeignKey(t => t.ProductDetailId);

            builder.HasOne(t => t.ImportingOrder)
                .WithMany(o => o.Transactions)
                .HasForeignKey(t => t.ImportingOrderId);
        }
    }
}