using System.Collections.Generic;
using System.Linq;
using Domain.Repositories;
using SouvenirShop.Domain.Entities;

namespace Infrastructure.Persistence
{
    public class SupplierRepository : EFRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(SouvenirShopDbContext db) : base(db)
        {
        }

        public IEnumerable<Supplier> GetAll()
        {
            return _db.Suppliers.ToList();
        }
    }
}