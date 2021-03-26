using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SouvenirShop.Domain.Entities;

namespace Infrastructure.Persistence.Config
{
    public class SellingOrderConfig : IEntityTypeConfiguration<SellingOrder>
    {
        public void Configure(EntityTypeBuilder<SellingOrder> builder)
        {
            builder.Property(o => o.DeliveryDate)
                .IsRequired();

            builder.Property(o => o.InvoiceDate)
                .IsRequired();

            builder.Property(o => o.ReceivePerson)
                .IsUnicode()
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(o => o.Status)
                .IsUnicode()
                .IsRequired();

            builder.Property(o => o.Address)
                .IsUnicode()
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(o => o.Total)
                .IsRequired();

            builder.HasOne(o => o.Customer)
                .WithMany(c => c.SellingOrders)
                .HasForeignKey(o => o.CustomerId);
        }
    }
}