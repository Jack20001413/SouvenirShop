using System.Collections.Generic;
using System.Linq;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Application.DTOs;
using SouvenirShop.Domain.Entities;
using SouvenirShop.Helpers;

namespace Infrastructure.Persistence
{
    public class SubCategoryRepository : EFRepository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(SouvenirShopDbContext db) : base(db)
        {
        }

        public IEnumerable<SubCategory> GetAll()
        {
            return _db.SubCategories.Include(s => s.Category).ToList();
        }
        public BaseSearchDto<SubCategory> GetAll(BaseSearchDto<SubCategoryDto> search)
        {
            var subCategorySearch = _db.SubCategories.Paginate(search.currentPage, search.recordOfPage);

            return new BaseSearchDto<SubCategory> {
                currentPage = search.currentPage,
                pagingRange = search.pagingRange,
                recordOfPage = search.recordOfPage,
                totalRecords = subCategorySearch.totalRecords,
                result = subCategorySearch.result.ToList()
            };
        }

        public List<SubCategory> GetLikeName(string name) {
            var subCategories = _db.SubCategories.Include(s => s.Category).Where(c => c.Name.Contains(name));
            return subCategories.ToList();
        }
    }
}