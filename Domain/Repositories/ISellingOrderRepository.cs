using System.Collections.Generic;
using Application.DTOs;
using SouvenirShop.Domain.Entities;

namespace Domain.Repositories
{
    public interface ISellingOrderRepository : IRepository<SellingOrder>
    {
        IEnumerable<SellingOrder> GetAll();
        BaseSearchDto<SellingOrder> GetAll(BaseSearchDto<SellingOrderDto> search);
        int GetLatestSellingOrderId();
    }
}