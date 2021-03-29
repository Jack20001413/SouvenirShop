using System.Collections.Generic;
using System.Linq;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SouvenirShop.Domain.Entities.Common;

namespace Infrastructure.Persistence
{
    public class CategoryRepository : EFRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(SouvenirShopDbContext db) : base(db)
        {
        }

        public IEnumerable<Category> GetAll()
        {
            return _db.Categories.ToList();
        }
    }
}