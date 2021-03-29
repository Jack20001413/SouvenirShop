using System.Collections.Generic;
using System.Linq;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SouvenirShop.Domain.Entities;

namespace Infrastructure.Persistence
{
    public class ProductRepository : EFRepository<Product>, IProductRepository
    {
        public ProductRepository(SouvenirShopDbContext db) : base(db)
        {
        }

        public IEnumerable<Product> GetAll()
        {
            return _db.Products.Include(p => p.SubCategory).ToList();
        }
    }
}