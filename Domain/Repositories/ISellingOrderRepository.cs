using System.Collections.Generic;
using Application.DTOs;
using SouvenirShop.Domain.Entities;
using System;
namespace Domain.Repositories
{
    public interface ISellingOrderRepository : IRepository<SellingOrder>
    {
        IEnumerable<SellingOrder> GetAll();
        BaseSearchDto<SellingOrder> GetAll(BaseSearchDto<SellingOrderDto> search);
        IEnumerable<SellingOrder> GetSellingOrderByCustomerId(int id);
        int GetLatestSellingOrderId();
    }
}