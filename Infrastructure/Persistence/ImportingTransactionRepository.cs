using System.Collections.Generic;
using System.Linq;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SouvenirShop.Domain.Entities;

namespace Infrastructure.Persistence
{
    public class ImportingTransactionRepository : EFRepository<ImportingTransaction>, IImportingTransactionRepository
    {
        public ImportingTransactionRepository(SouvenirShopDbContext db) : base(db)
        {
        }

        public IEnumerable<ImportingTransaction> GetAll()
        {
            return _db.ImportingTransactions.Include(t => t.ImportingOrder)
                .Include(t => t.ProductDetail).ToList();
        }
    }
}