using System.Collections.Generic;
using SouvenirShop.Domain.Entities;

namespace Domain.Repositories
{
    public interface IProductDetailRepository : IRepository<ProductDetail>
    {
        IEnumerable<ProductDetail> GetAll();
    }
}