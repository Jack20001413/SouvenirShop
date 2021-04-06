using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IGrantPermissionService
    {
        IEnumerable<GrantPermissionDto> GetAll();
        GrantPermissionDto GetGrantPermission(int id);
        GrantPermissionDto CreateGrantPermission(GrantPermissionDto grantPermissionDto);
        GrantPermissionDto UpdateGrantPermission(GrantPermissionDto grantPermissionDto);
        GrantPermissionDto DeleteGrantPermission(int id);
         bool GrantPermissionExists(int id); 
    }
}