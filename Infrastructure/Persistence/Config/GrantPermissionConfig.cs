using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SouvenirShop.Domain.Entities;

namespace Infrastructure.Persistence.Config
{
    public class GrantPermissionConfig : IEntityTypeConfiguration<GrantPermission>
    {
        public void Configure(EntityTypeBuilder<GrantPermission> builder)
        {
            builder.HasOne(g => g.Role)
                .WithMany(r => r.GrantPermissions)
                .HasForeignKey(g => g.RoleId);

            builder.HasOne(g => g.Permission)
                .WithMany(p => p.GrantPermissions)
                .HasForeignKey(g => g.PermissionId);
        }
    }
}