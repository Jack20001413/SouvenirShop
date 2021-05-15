using System.Collections.Generic;
using System.Linq;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SouvenirShop.Domain.Entities;

namespace Infrastructure.Persistence
{
    public class SellingTransactionRepository : EFRepository<SellingTransaction>, ISellingTransactionRepository
    {
        public SellingTransactionRepository(SouvenirShopDbContext db) : base(db)
        {
        }

        public IEnumerable<SellingTransaction> GetAll()
        {
            return _db.SellingTransactions.Include(t => t.ProductDetail)
                .Include(t => t.ProductDetail).ToList();
        }

        public List<SellingTransaction> GetTransactionBySellingId(int id)
        {
            var transactions = _db.SellingTransactions.Where(c => c.SellingOrderId == id).Include(t => t.ProductDetail);
            return transactions.ToList();
        }
    }
}