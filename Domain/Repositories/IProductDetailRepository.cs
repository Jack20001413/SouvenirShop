using System.Collections.Generic;
using Application.DTOs;
using SouvenirShop.Domain.Entities;

namespace Domain.Repositories
{
    public interface IProductDetailRepository : IRepository<ProductDetail>
    {
        IEnumerable<ProductDetail> GetAll();
        
        BaseSearchDto<ProductDetail> GetAll(BaseSearchDto<ProductDetailDto> search);
    }
}