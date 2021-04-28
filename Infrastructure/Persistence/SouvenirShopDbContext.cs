using Microsoft.EntityFrameworkCore;
using SouvenirShop.Domain.Entities;
using SouvenirShop.Domain.Entities.Common;
using System;
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

            //Create Data Seed
            modelBuilder.Entity<Employee>().HasData(
                new Employee{
                    Id = 1,
                    Name = "Admin Test",
                    Email = "admin@gmail.com",
                    Password = "123456",
                    BirthDate = DateTime.Parse("2000-12-26"),
                    RoleId = 1
                }
            );

            modelBuilder.Entity<Role>().HasData(
                new Role{
                    Id = 1,
                    Name = "Admin"
                }
            );

            modelBuilder.Entity<Permission>().HasData(
                new Permission{
                    Id = 1,
                    Code = "PRODUCT_MANAGEMENT",
                    Description = "Quản lý hàng hoá"
                },
                new Permission{
                    Id = 2,
                    Code = "CUSTOMER_MANAGEMENT",
                    Description = "Quản lý khách hàng"
                },
                new Permission{
                    Id = 3,
                    Code = "EMPLOYEE_MANAGEMENT",
                    Description = "Quản lý nhân viên"
                },
                new Permission{
                    Id = 4,
                    Code = "SUPPLIER_MANAGEMENT",
                    Description = "Quản lý nhà cung cấp"
                }
            );
        }

        
    }
}