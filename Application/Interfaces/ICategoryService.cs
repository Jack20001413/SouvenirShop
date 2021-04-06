using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetAll();
        CategoryDto GetCategory(int id);
         CategoryDto CreateCategory(CategoryDto categoryDto);
         CategoryDto UpdateCategory(CategoryDto categoryDto);
         CategoryDto DeleteCategory(int id);
         bool CategoryExists(int id); 
    }
}