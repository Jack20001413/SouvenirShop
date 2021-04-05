using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAll();
        ProductDto GetProduct(int id);
        ProductDto CreateProduct(ProductDto product);
        ProductDto UpdateProduct(ProductDto product);
        ProductDto DeleteProduct(int id);
        bool ProductExists(int id); 
    }
}