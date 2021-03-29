using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IPermissionService
    {
        IEnumerable<PermissionDto> GetAll();
        PermissionDto GetPermission(int id);
         void CreatePermission(PermissionDto permission);
         void UpdatePermission(PermissionDto permission);
         void DeletePermission(PermissionDto permission);
         bool PermissionExists(int id); 
    }
}