using System.Collections.Generic;
using SouvenirShop.Domain.Entities;

namespace Domain.Repositories
{
    public interface ISellingTransactionRepository : IRepository<SellingTransaction>
    {
        IEnumerable<SellingTransaction> GetAll();
        List<SellingTransaction> GetTransactionBySellingId(int id);

    }
}