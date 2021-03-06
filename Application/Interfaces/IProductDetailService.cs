using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IProductDetailService
    {
        IEnumerable<ProductDetailDto> GetAll();
        BaseSearchDto<ProductDetailDto> GetAll(BaseSearchDto<ProductDetailDto> searchDto);
        ProductDetailDto GetProductDetail(int id);
        ProductDetailDto CreateProductDetail(ProductDetailDto productDetailDto);
        ProductDetailDto UpdateProductDetail(ProductDetailDto productDetailDto);
        ProductDetailDto DeleteProductDetail(int id);
        bool ProductDetailExists(int id); 
    }
}