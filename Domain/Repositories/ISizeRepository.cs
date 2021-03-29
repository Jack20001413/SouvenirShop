using System.Collections.Generic;
using SouvenirShop.Domain.Entities;

namespace Domain.Repositories
{
    public interface ISizeRepository : IRepository<Size>
    {
        IEnumerable<Size> GetAll();
    }
}