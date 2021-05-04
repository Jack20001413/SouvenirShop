using System.Collections.Generic;
using System.Linq;
using Application.DTOs;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SouvenirShop.Domain.Entities;
using SouvenirShop.Helpers;

namespace Infrastructure.Persistence
{
    public class ProductDetailRepository : EFRepository<ProductDetail>, IProductDetailRepository
    {
        public ProductDetailRepository(SouvenirShopDbContext db) : base(db)
        {
        }

        public IEnumerable<ProductDetail> GetAll()
        {
            return _db.ProductDetails.Include(p => p.Product).Include(p => p.Color)
                .Include(p => p.Size).ToList();
        }
         public BaseSearchDto<ProductDetail> GetAll(BaseSearchDto<ProductDetailDto> search)
        {
            var productSearch = _db.ProductDetails.Paginate(search.currentPage, search.recordOfPage);

            return new BaseSearchDto<ProductDetail> {
                currentPage = search.currentPage,
                pagingRange = search.pagingRange,
                recordOfPage = search.recordOfPage,
                totalRecords = productSearch.totalRecords,
                result = productSearch.result.ToList()
            };
        }
    }
}