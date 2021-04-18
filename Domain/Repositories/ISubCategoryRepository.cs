using System.Collections.Generic;
using SouvenirShop.Domain.Entities;
using Application.DTOs;

namespace Domain.Repositories
{
    public interface ISubCategoryRepository : IRepository<SubCategory>
    {
        IEnumerable<SubCategory> GetAll();
        BaseSearchDto<SubCategory> GetAll(BaseSearchDto<SubCategoryDto> search);
        List<SubCategory> GetLikeName(string name);
    }
}