using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SouvenirShop.Domain.Entities;

namespace Infrastructure.Persistence.Config
{
    public class ImportingOrderConfig : IEntityTypeConfiguration<ImportingOrder>
    {
        public void Configure(EntityTypeBuilder<ImportingOrder> builder)
        {
            builder.Property(o => o.InvoiceDate)
                .IsRequired();

            builder.Property(o => o.Status)
                .IsRequired();

            builder.Property(o => o.Total)
                .IsRequired();

            builder.Property(o => o.DeliveryDate)
                .IsRequired();

            builder.HasOne(o => o.Employee)
                .WithMany(e => e.ImportingOrders)
                .HasForeignKey(o => o.EmployeeId);

            builder.HasOne(o => o.Supplier)
                .WithMany(s => s.Orders)
                .HasForeignKey(o => o.SupplierId);
        }
    }
}