using System.Collections.Generic;
using System.Linq;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SouvenirShop.Domain.Entities;
using Application.DTOs;
using SouvenirShop.Helpers;

namespace Infrastructure.Persistence
{
    public class SizeRepository : EFRepository<Size>, ISizeRepository
    {
        public SizeRepository(SouvenirShopDbContext db) : base(db)
        {
        }

        public IEnumerable<Size> GetAll()
        {
            return _db.Sizes.ToList();
        }

        public BaseSearchDto<Size> GetAll(BaseSearchDto<SizeDto> search)
        {
            var sizeSearch = _db.Sizes.Paginate(search.currentPage, search.recordOfPage);
            return new BaseSearchDto<Size> {
                currentPage = search.currentPage,
                pagingRange = search.pagingRange,
                recordOfPage = search.recordOfPage,
                totalRecords = sizeSearch.totalRecords,
                result = sizeSearch.result.ToList()
            };
        }

        public List<Size> GetLikeName(string name) {
            var sizes = _db.Sizes.Where(c => c.Name.Contains(name));
            return sizes.ToList();
        }
    }
}