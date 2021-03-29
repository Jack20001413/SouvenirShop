using System.Collections.Generic;
using SouvenirShop.Domain.Entities;

namespace Domain.Repositories
{
    public interface ISellingOrderRepository : IRepository<SellingOrder>
    {
        IEnumerable<SellingOrder> GetAll();
    }
}