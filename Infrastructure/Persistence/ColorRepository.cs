using System.Collections.Generic;
using System.Linq;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SouvenirShop.Domain.Entities;

namespace Infrastructure.Persistence
{
    public class ColorRepository : EFRepository<Color>, IColorRepository
    {
        public ColorRepository(SouvenirShopDbContext db) : base(db)
        {
        }

        public IEnumerable<Color> GetAll()
        {
            return _db.Colors.ToList();
        }
    }
}