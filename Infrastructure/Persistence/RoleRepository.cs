using System.Collections.Generic;
using System.Linq;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Application.DTOs;
using SouvenirShop.Domain.Entities;
using SouvenirShop.Helpers;

namespace Infrastructure.Persistence
{
    public class RoleRepository : EFRepository<Role>, IRoleRepository
    {
        public RoleRepository(SouvenirShopDbContext db): base(db)
        {
            
        }

        public IEnumerable<Role> GetAll()
        {
            return _db.Roles.ToList();
        }

        public BaseSearchDto<Role> GetAll(BaseSearchDto<RoleDto> search)
        {
            var roleSearch = _db.Roles.Paginate(search.currentPage, search.recordOfPage);
            return new BaseSearchDto<Role> {
                currentPage = search.currentPage,
                pagingRange = search.pagingRange,
                recordOfPage = search.recordOfPage,
                totalRecords = roleSearch.totalRecords,
                result = roleSearch.result.ToList()
            };
        }

        public List<Role> GetLikeName(string name) {
            var roles = _db.Roles.Where(c => c.Name.Contains(name));
            return roles.ToList();
        }
    }
}