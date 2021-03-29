using System.Collections.Generic;
using System.Linq;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SouvenirShop.Domain.Entities;

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
    }
}