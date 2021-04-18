using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpGet("find-all")]
        public ActionResult<IEnumerable<PermissionDto>> GetAll(){
            var permissions = _permissionService.GetAll();
            if (permissions == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, permissions));
            }
            List<string> successMessage = new List<string>();
            successMessage.Add("Lấy danh sách phân quyền thành công");
            var responseDto = new ResponseDto(successMessage, 200, permissions);
            return Ok(responseDto);
        }
    }
}