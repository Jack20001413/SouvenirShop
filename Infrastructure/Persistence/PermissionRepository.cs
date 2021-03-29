using System.Collections.Generic;
using System.Linq;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SouvenirShop.Domain.Entities;

namespace Infrastructure.Persistence
{
    public class PermissionRepository : EFRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(SouvenirShopDbContext db) : base(db)
        {
        }

        public IEnumerable<Permission> GetAll()
        {
            return _db.Permissions.ToList();
        }
    }
}