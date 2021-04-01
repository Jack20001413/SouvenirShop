using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IProductDetailService
    {
        IEnumerable<ProductDetailDto> GetAll();
        ProductDetailDto GetProductDetail(int id);
        void CreateProductDetail(ProductDetailDto productDetail);
        void UpdateProductDetail(ProductDetailDto productDetail);
        void DeleteProductDetail(ProductDetailDto productDetail);
        bool ProductDetailExists(int id); 
    }
}