using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IRoleService
    {
        IEnumerable<RoleDto> GetAll();
        RoleDto GetRole(int id);
         void CreateRole(RoleDto role);
         void UpdateRole(RoleDto role);
         void DeleteRole(RoleDto role);
         bool RoleExists(int id); 
    }
}