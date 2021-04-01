using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAll();
        ProductDto GetProduct(int id);
         void CreateProduct(ProductDto product);
         void UpdateProduct(ProductDto product);
         void DeleteProduct(ProductDto product);
         bool ProductExists(int id); 
    }
}