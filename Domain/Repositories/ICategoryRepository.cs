using System.Collections.Generic;
using SouvenirShop.Domain.Entities.Common;
using Application.DTOs;

namespace Domain.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> GetAll();
        BaseSearchDto<Category> GetAll(BaseSearchDto<CategoryDto> search);
        List<Category> GetLikeName(string name);
    }
}