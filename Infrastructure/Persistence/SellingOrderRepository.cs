using System.Collections.Generic;
using System.Linq;
using Application.DTOs;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SouvenirShop.Domain.Entities;
using SouvenirShop.Helpers;

namespace Infrastructure.Persistence
{
    public class SellingOrderRepository : EFRepository<SellingOrder>, ISellingOrderRepository
    {
        public SellingOrderRepository(SouvenirShopDbContext db) : base(db)
        {
        }

        public IEnumerable<SellingOrder> GetAll()
        {
            return _db.SellingOrders.Include(o => o.Customer).ToList();
        }

        public BaseSearchDto<SellingOrder> GetAll(BaseSearchDto<SellingOrderDto> search)
        {
            var orderSearch = _db.SellingOrders.Paginate(search.currentPage, search.recordOfPage);

            return new BaseSearchDto<SellingOrder> {
                currentPage = search.currentPage,
                pagingRange = search.pagingRange,
                recordOfPage = search.recordOfPage,
                totalRecords = orderSearch.totalRecords,
                result = orderSearch.result.ToList()
            };
        }

        public IEnumerable<SellingOrder> GetSellingOrderByCustomerId(int id)
        {
            var order = _db.SellingOrders.Where(o => o.CustomerId == id);
            return order.ToList();
        }
        
        public int GetLatestSellingOrderId() {
            var id = _db.SellingOrders.Max(p => p.Id);
            return id;
        }
    }
}