using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface ISubCategoryService
    {
        IEnumerable<SubCategoryDto> GetAll();
        SubCategoryDto GetSubCategory(int id);
        SubCategoryDto CreateSubCategory(SubCategoryDto subCategoryDto);
        SubCategoryDto UpdateSubCategory(SubCategoryDto subCategoryDto);
        SubCategoryDto DeleteSubCategory(int id);
         bool SubCategoryExists(int id); 
    }
}