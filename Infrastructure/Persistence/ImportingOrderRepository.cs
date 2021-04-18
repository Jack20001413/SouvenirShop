using System.Collections.Generic;
using System.Linq;
using Application.DTOs;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SouvenirShop.Domain.Entities;
using SouvenirShop.Helpers;

namespace Infrastructure.Persistence
{
    public class ImportingOrderRepository : EFRepository<ImportingOrder>, IImportingOrderRepository
    {
        public ImportingOrderRepository(SouvenirShopDbContext db) : base(db)
        {
        }

        public IEnumerable<ImportingOrder> GetAll()
        {
            return _db.ImportingOders.Include(o => o.Employee).Include(o => o.Supplier).ToList();
        }

        public BaseSearchDto<ImportingOrder> GetAll(BaseSearchDto<ImportingOrderDto> search)
        {
            var orderSearch = _db.ImportingOders.Paginate(search.currentPage, search.recordOfPage);

            return new BaseSearchDto<ImportingOrder> {
                currentPage = search.currentPage,
                pagingRange = search.pagingRange,
                recordOfPage = search.recordOfPage,
                totalRecords = orderSearch.totalRecords,
                result = orderSearch.result.ToList()
            };
        }
    }
}