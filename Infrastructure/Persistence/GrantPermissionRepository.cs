using System.Collections.Generic;
using System.Linq;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SouvenirShop.Domain.Entities;

namespace Infrastructure.Persistence
{
    public class GrantPermissionRepository : EFRepository<GrantPermission>, IGrantPermissionRepository
    {
        public GrantPermissionRepository(SouvenirShopDbContext db) : base(db)
        {
        }

        public IEnumerable<GrantPermission> GetAll()
        {
            return _db.GrantPermissions.Include(g => g.Role).Include(g => g.Permission).ToList();
        }

        public IEnumerable<GrantPermission> GetByRoleId(int roleId)
        {
            return _db.GrantPermissions.Where(s => s.RoleId == roleId)
            .Include(s => s.Role)
            .Include(s => s.Permission)
            .ToList();
        }

        
    }
}