using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IRoleService
    {
        IEnumerable<RoleDto> GetAll();
        BaseSearchDto<RoleDto> GetAll(BaseSearchDto<RoleDto> searchDto);
        List<RoleDto> GetLikeName(string name);
        RoleFullDto GetRole(int id);
        RoleFullDto CreateRole(RoleFullDto roleFullDto);
        RoleFullDto UpdateRole(RoleFullDto roleFullDto);
        RoleDto DeleteRole(int id);
        bool RoleExists(int id); 
    }
}