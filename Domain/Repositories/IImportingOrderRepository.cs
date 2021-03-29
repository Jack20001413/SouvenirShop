using System.Collections.Generic;
using SouvenirShop.Domain.Entities;

namespace Domain.Repositories
{
    public interface IImportingOrderRepository : IRepository<ImportingOrder>
    {
        IEnumerable<ImportingOrder> GetAll();
    }
}