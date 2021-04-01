using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface ISellingOrderService
    {
        IEnumerable<SellingOrderDto> GetAll();
        SellingOrderDto GetSellingOrder(int id);
         void CreateSellingOrder(SellingOrderDto order);
         void UpdateSellingOrder(SellingOrderDto order);
         void DeleteSellingOrder(SellingOrderDto order);
         bool SellingOrderExists(int id); 
    }
}