using System.Collections.Generic;
using System.Linq;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SouvenirShop.Domain.Entities;

namespace Infrastructure.Persistence
{
    public class ProductDetailRepository : EFRepository<ProductDetail>, IProductDetailRepository
    {
        public ProductDetailRepository(SouvenirShopDbContext db) : base(db)
        {
        }

        public IEnumerable<ProductDetail> GetAll()
        {
            return _db.ProductDetails.Include(p => p.Product).Include(p => p.Color)
                .Include(p => p.Size).ToList();
        }
    }
}