using System;
using System.Collections.Generic;
using SouvenirShop.Domain.Entities;

namespace Domain.Repositories
{
    public interface IGrantPermissionRepository : IRepository<GrantPermission>
    {
        IEnumerable<GrantPermission> GetAll();
        IEnumerable<GrantPermission> GetByRoleId(int roleId);
    }
}