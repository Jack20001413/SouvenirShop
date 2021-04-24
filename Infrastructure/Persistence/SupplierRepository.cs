using System.Collections.Generic;
using System.Linq;
using Application.DTOs;
using Domain.Repositories;
using SouvenirShop.Domain.Entities;
using SouvenirShop.Helpers;

namespace Infrastructure.Persistence
{
    public class SupplierRepository : EFRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(SouvenirShopDbContext db) : base(db)
        {
        }

        public IEnumerable<Supplier> GetAll()
        {
            return _db.Suppliers.ToList();
        }

        public BaseSearchDto<Supplier> GetAll(BaseSearchDto<SupplierDto> searchDto)
        {
            var supplierSearch = _db.Suppliers.Paginate(searchDto.currentPage, searchDto.recordOfPage);
            return new BaseSearchDto<Supplier>{
                currentPage = searchDto.currentPage,
                pagingRange = searchDto.pagingRange,
                recordOfPage = searchDto.recordOfPage,
                totalRecords = supplierSearch.totalRecords,
                result = supplierSearch.result.ToList()
            };
        }

        public List<Supplier> GetLikeName(string name)
        {
            var suppliers = _db.Suppliers.Where(c => c.Name.Contains(name));
            return suppliers.ToList();
        }
    }
}