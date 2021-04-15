using System.Collections.Generic;
using SouvenirShop.Domain.Entities;
using SouvenirShop.Domain.Entities.Common;
using Application.DTOs;

namespace Domain.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        IEnumerable<Role> GetAll();
        BaseSearchDto<Role> GetAll(BaseSearchDto<RoleDto> search);
        List<Role> GetLikeName(string name);
    }
}