using System.Collections.Generic;
using System.Linq;
using Application.DTOs;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SouvenirShop.Domain.Entities;
using SouvenirShop.Helpers;

namespace Infrastructure.Persistence
{
    public class ProductRepository : EFRepository<Product>, IProductRepository
    {
        public ProductRepository(SouvenirShopDbContext db) : base(db)
        {
        }

        public IEnumerable<Product> GetAll()
        {
            return _db.Products.Include(p => p.SubCategory).ToList();
        }

        public BaseSearchDto<Product> GetAll(BaseSearchDto<ProductDto> search)
        {
            var productSearch = _db.Products.Paginate(search.currentPage, search.recordOfPage);

            return new BaseSearchDto<Product> {
                currentPage = search.currentPage,
                pagingRange = search.pagingRange,
                recordOfPage = search.recordOfPage,
                totalRecords = productSearch.totalRecords,
                result = productSearch.result.ToList()
            };
        }

        public List<Product> GetLikeName(string name)
        {
            var products = _db.Products.Where(c => c.Name.Contains(name));
            return products.ToList();
        }

        public List<Product> GetList(int id)
        {
            var products = _db.Products.Where(p => p.SubCategoryId == id);
            return products.ToList();
        }
    }
}