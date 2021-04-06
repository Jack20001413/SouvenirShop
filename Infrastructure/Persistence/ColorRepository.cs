using System.Collections.Generic;
using System.Linq;
using Application.DTOs;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SouvenirShop.Domain.Entities;
using SouvenirShop.Helpers;

namespace Infrastructure.Persistence
{
    public class ColorRepository : EFRepository<Color>, IColorRepository
    {
        public ColorRepository(SouvenirShopDbContext db) : base(db)
        {
        }

        public IEnumerable<Color> GetAll()
        {
            return _db.Colors.ToList();
        }

        public BaseSearchDto<Color> GetAll(BaseSearchDto<ColorDto> search)
        {
            var colorSearch = _db.Colors.Paginate(search.currentPage, search.recordOfPage);
            return new BaseSearchDto<Color> {
                currentPage = search.currentPage,
                pagingRange = search.pagingRange,
                recordOfPage = search.recordOfPage,
                totalRecords = colorSearch.totalRecords,
                result = colorSearch.result.ToList()
            };
        }
    }
}