using System.Collections.Generic;
using SouvenirShop.Domain.Entities;
using Application.DTOs;
using SouvenirShop.Domain.Entities.Common;

namespace Domain.Repositories
{
    public interface ISubCategoryRepository : IRepository<SubCategory>
    {
        IEnumerable<SubCategory> GetAll();
        BaseSearchDto<SubCategory> GetAll(BaseSearchDto<SubCategoryDto> search);
        List<SubCategory> GetLikeName(string name);
        List<SubCategory> GetSubCategoryByCategoryId(int id);
    }
}