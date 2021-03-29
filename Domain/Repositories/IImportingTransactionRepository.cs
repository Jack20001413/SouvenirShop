using System.Collections.Generic;
using SouvenirShop.Domain.Entities;

namespace Domain.Repositories
{
    public interface IImportingTransactionRepository : IRepository<ImportingTransaction>
    {
        IEnumerable<ImportingTransaction> GetAll();
    }
}