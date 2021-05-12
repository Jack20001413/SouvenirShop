using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryFullDto> GetAll();
        BaseSearchDto<CategoryDto> GetAll(BaseSearchDto<CategoryDto> searchDto);
        List<CategoryDto> GetLikeName(string name);
        CategoryDto GetCategory(int id);
        CategoryDto CreateCategory(CategoryDto categoryDto);
        CategoryDto UpdateCategory(CategoryDto categoryDto);
        CategoryDto DeleteCategory(int id);
        bool CategoryExists(int id); 
        IEnumerable<SubCategoryDto> GetSubCategories(int subCategoryId);
        IEnumerable<SubCategoryDto> GetSubCategoriesByCategory(int categoryId);
    }
}