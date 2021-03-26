using Microsoft.EntityFrameworkCore;
using SouvenirShop.Domain.Entities;
using SouvenirShop.Domain.Entities.Common;
using System.Reflection;

namespace Infrastructure.Persistence
{
    public class SouvenirShopDbContext : DbContext
    {
        public SouvenirShopDbContext(DbContextOptions<SouvenirShopDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<GrantPermission> GrantPermissions { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<SellingOrder> SellingOrders { get; set; }
        public DbSet<SellingTransaction> SellingTransactions { get; set; }
        public DbSet<ImportingOrder> ImportingOders { get; set; }
        public DbSet<ImportingTransaction> ImportingTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}