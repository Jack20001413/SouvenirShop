using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RoleDto>> GetAll(){
            var roles = _roleService.GetAll();
            if( roles == null){
                return NotFound("Empty list");
            }
            return Ok(roles);
        }

        [HttpPost("search")]
        public ActionResult<BaseSearchDto<RoleDto>> GetAll([FromBody] BaseSearchDto<RoleDto> searchDto) {
            var search = _roleService.GetAll(searchDto);
            if (search == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, search));
            }
            List<string> successMessage = new List<string>();
            successMessage.Add("Lấy danh sách quyền thành công");
            var responseDto = new ResponseDto(successMessage, 200, search);
            return Ok(responseDto);
        }

        [HttpGet("get-like-name/{name}")]
        public ActionResult<List<RoleDto>> GetLikeName(string name){
            var categories = _roleService.GetLikeName(name);

            if (categories == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, categories));
            }
            List<string> successMessage = new List<string>();
            successMessage.Add("Lấy thông tin thành công");
            var responseDto = new ResponseDto(successMessage, 200, categories);
            return Ok(responseDto);
        }

        [HttpGet("{id}")]
        public ActionResult<RoleFullDto> GetARoleFull(int id){
            var roleFull = _roleService.GetRole(id);

            if (roleFull == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, roleFull));
            }
            List<string> successMessage = new List<string>();
            successMessage.Add("Lấy thông tin thành công");
            var responseDto = new ResponseDto(successMessage, 200, roleFull);
            return Ok(responseDto);
        }

        [HttpPost("insert")]
        public ActionResult<RoleDto> CreateRole([FromBody] RoleFullDto roleFull){
            var roleFullDto = _roleService.CreateRole(roleFull);

            if (roleFullDto == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, roleFullDto));
            }
            List<string> successMessage = new List<string>();
            successMessage.Add("Thêm thông tin thành công");
            var responseDto = new ResponseDto(successMessage, 200, roleFullDto);
            return Ok(responseDto);
        }

        [HttpPut("update")]
        public ActionResult<RoleDto> UpdateRole([FromBody] RoleFullDto roleFull){
            var roleFullDto = _roleService.UpdateRole(roleFull);

            if (roleFullDto == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, roleFullDto));
            }
            List<string> successMessage = new List<string>();
            successMessage.Add("Sửa thông tin thành công");
            var responseDto = new ResponseDto(successMessage, 200, roleFullDto);
            return Ok(responseDto);
        }

        [HttpDelete("delete/{id:int}")]
        public ActionResult<RoleDto> DeleteRole(int id){
            var RoleDto = _roleService.DeleteRole(id);

            if (RoleDto == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, ""));
            }
            List<string> successMessage = new List<string>();
            successMessage.Add("Xoá thành công");
            var responseDto = new ResponseDto(successMessage, 200, "");
            return Ok(responseDto);
        }
    }
}