using System.Collections.Generic;
using System.Linq;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SouvenirShop.Domain.Entities;

namespace Infrastructure.Persistence
{
    public class SellingOrderRepository : EFRepository<SellingOrder>, ISellingOrderRepository
    {
        public SellingOrderRepository(SouvenirShopDbContext db) : base(db)
        {
        }

        public IEnumerable<SellingOrder> GetAll()
        {
            return _db.SellingOrders.Include(o => o.Customer).ToList();
        }
    }
}