using System.Collections.Generic;
using System.Linq;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SouvenirShop.Domain.Entities;

namespace Infrastructure.Persistence
{
    public class SubCategoryRepository : EFRepository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(SouvenirShopDbContext db) : base(db)
        {
        }

        public IEnumerable<SubCategory> GetAll()
        {
            return _db.SubCategories.Include(s => s.Category).ToList();
        }
    }
}