using System.Collections.Generic;
using SouvenirShop.Domain.Entities;

namespace Domain.Repositories
{
    public interface IColorRepository : IRepository<Color>
    {
        IEnumerable<Color> GetAll();
    }
}