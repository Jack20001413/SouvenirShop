using System.Collections.Generic;
using System.Linq;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SouvenirShop.Domain.Entities;

namespace Infrastructure.Persistence
{
    public class ImportingOrderRepository : EFRepository<ImportingOrder>, IImportingOrderRepository
    {
        public ImportingOrderRepository(SouvenirShopDbContext db) : base(db)
        {
        }

        public IEnumerable<ImportingOrder> GetAll()
        {
            return _db.ImportingOders.Include(o => o.Employee).Include(o => o.Supplier).ToList();
        }
    }
}