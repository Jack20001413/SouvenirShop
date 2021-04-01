using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface ISubCategoryService
    {
        IEnumerable<SubCategoryDto> GetAll();
        SubCategoryDto GetSubCategory(int id);
         void CreateSubCategory(SubCategoryDto subCategory);
         void UpdateSubCategory(SubCategoryDto subCategory);
         void DeleteSubCategory(SubCategoryDto subCategory);
         bool SubCategoryExists(int id); 
    }
}