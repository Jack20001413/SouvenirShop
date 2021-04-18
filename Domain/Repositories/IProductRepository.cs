using System.Collections.Generic;
using Application.DTOs;
using SouvenirShop.Domain.Entities;

namespace Domain.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetAll();
        BaseSearchDto<Product> GetAll(BaseSearchDto<ProductDto> search);
        List<Product> GetLikeName(string name);
    }
}