using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface ISellingOrderService
    {
        IEnumerable<SellingOrderDto> GetAll();
        SellingOrderDto GetSellingOrder(int id);
        SellingOrderDto CreateSellingOrder(SellingOrderDto orderDto);
        SellingOrderDto UpdateSellingOrder(SellingOrderDto orderDto);
        SellingOrderDto DeleteSellingOrder(int id);
        bool SellingOrderExists(int id); 
        BaseSearchDto<SellingOrderDto> GetAll(BaseSearchDto<SellingOrderDto> searchDto);
        IEnumerable<SellingTransactionDto> GetSellingTransactionByOrderId(int id);
        IEnumerable<SellingOrderDto> GetSellingOrderByCustomerId(int id);
        OrderPaymentIntentDto CreatePaymentIntent(int orderId);
        List<MonthCostDetailDto> getMonthCostDetails(RangeDateDto rangeDateDto);
    }
}