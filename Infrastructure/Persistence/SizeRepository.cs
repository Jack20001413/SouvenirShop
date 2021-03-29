using System.Collections.Generic;
using System.Linq;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SouvenirShop.Domain.Entities;

namespace Infrastructure.Persistence
{
    public class SizeRepository : EFRepository<Size>, ISizeRepository
    {
        public SizeRepository(SouvenirShopDbContext db) : base(db)
        {
        }

        public IEnumerable<Size> GetAll()
        {
            return _db.Sizes.ToList();
        }
    }
}