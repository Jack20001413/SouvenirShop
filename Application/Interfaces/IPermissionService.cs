using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IPermissionService
    {
        IEnumerable<PermissionDto> GetAll();
    }
}