using System.Collections.Generic;
using Application.DTOs;
using SouvenirShop.Domain.Entities;

namespace Domain.Repositories
{
    public interface ISizeRepository : IRepository<Size>
    {
        IEnumerable<Size> GetAll();
        BaseSearchDto<Size> GetAll(BaseSearchDto<SizeDto> search);
    }
}