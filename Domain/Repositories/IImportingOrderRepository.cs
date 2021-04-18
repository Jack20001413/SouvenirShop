using System.Collections.Generic;
using Application.DTOs;
using SouvenirShop.Domain.Entities;

namespace Domain.Repositories
{
    public interface IImportingOrderRepository : IRepository<ImportingOrder>
    {
        IEnumerable<ImportingOrder> GetAll();
        BaseSearchDto<ImportingOrder> GetAll(BaseSearchDto<ImportingOrderDto> search);
    }
}