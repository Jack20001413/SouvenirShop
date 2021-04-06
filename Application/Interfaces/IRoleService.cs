using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IRoleService
    {
        IEnumerable<RoleDto> GetAll();
        RoleDto GetRole(int id);
        RoleDto CreateRole(RoleDto roleDto);
        RoleDto UpdateRole(RoleDto roleDto);
        RoleDto DeleteRole(int id);
        bool RoleExists(int id); 
    }
}