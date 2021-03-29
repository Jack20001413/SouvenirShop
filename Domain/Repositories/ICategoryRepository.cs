using System.Collections.Generic;
using SouvenirShop.Domain.Entities.Common;

namespace Domain.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> GetAll();
    }
}