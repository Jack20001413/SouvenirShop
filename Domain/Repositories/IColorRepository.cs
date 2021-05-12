using System.Collections.Generic;
using Application.DTOs;
using SouvenirShop.Domain.Entities;

namespace Domain.Repositories
{
    public interface IColorRepository : IRepository<Color>
    {
        IEnumerable<Color> GetAll();
        BaseSearchDto<Color> GetAll(BaseSearchDto<ColorDto> search);
        List<Color> GetLikeName(string name);
    }
}