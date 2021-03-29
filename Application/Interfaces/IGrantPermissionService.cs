using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IGrantPermissionService
    {
        IEnumerable<GrantPermissionDto> GetAll();
        GrantPermissionDto GetGrantPermission(int id);
         void CreateGrantPermission(GrantPermissionDto grantPermission);
         void UpdateGrantPermission(GrantPermissionDto grantPermission);
         void DeleteGrantPermission(GrantPermissionDto grantPermission);
         bool GrantPermissionExists(int id); 
    }
}