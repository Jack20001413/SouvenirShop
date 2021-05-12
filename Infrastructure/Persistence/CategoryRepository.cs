using System.Collections.Generic;
using System.Linq;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SouvenirShop.Domain.Entities.Common;
using Application.DTOs;
using SouvenirShop.Domain.Entities;
using SouvenirShop.Helpers;

namespace Infrastructure.Persistence
{
    public class CategoryRepository : EFRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(SouvenirShopDbContext db) : base(db)
        {
        }

        public IEnumerable<Category> GetAll()
        {
            return _db.Categories.ToList();
        }

        public BaseSearchDto<Category> GetAll(BaseSearchDto<CategoryDto> search)
        {
            var categorySearch = _db.Categories.Paginate(search.currentPage, search.recordOfPage);
            return new BaseSearchDto<Category> {
                currentPage = search.currentPage,
                pagingRange = search.pagingRange,
                recordOfPage = search.recordOfPage,
                totalRecords = categorySearch.totalRecords,
                result = categorySearch.result.ToList()
            };
        }

        public Category GetCategoryBySubCategoryId(int id)
        {
            var subCategory = _db.SubCategories.Find(id);
            var category = _db.Categories.Find(subCategory.CategoryId);
            return category;
        }

        public List<Category> GetLikeName(string name) {
            var categories = _db.Categories.Where(c => c.Name.Contains(name));
            return categories.ToList();
        }

        public IEnumerable<SubCategory> GetSubCategories(int id)
        {
            var subCategories = _db.SubCategories.Where(c => c.CategoryId == id);
            return subCategories.ToList();
        }
    }
}