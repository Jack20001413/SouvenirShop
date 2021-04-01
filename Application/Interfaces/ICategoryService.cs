using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetAll();
        CategoryDto GetCategory(int id);
         void CreateCategory(CategoryDto category);
         void UpdateCategory(CategoryDto category);
         void DeleteCategory(CategoryDto category);
         bool CategoryExists(int id); 
    }
}