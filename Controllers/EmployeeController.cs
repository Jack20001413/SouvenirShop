using System;
using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EmployeeDto>> GetAll(){
            var employees = _employeeService.GetAll();
            
            if( employees == null){
                 List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, employees));
            }

            List<string> successMessage = new List<string>();
            successMessage.Add("Lấy danh mục nhân viên thành công");
            var responseDto = new ResponseDto(successMessage, 200, employees);
            return Ok(responseDto);
        }

        [HttpPost("search")]
        public ActionResult<BaseSearchDto<EmployeeDto>> GetAll([FromBody] BaseSearchDto<EmployeeDto> searchDto) {
            var search = _employeeService.GetAll(searchDto);

            if (search == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, search));
            }

            List<string> successMessage = new List<string>();
            successMessage.Add("Lấy danh mục nhân viên thành công");
            var responseDto = new ResponseDto(successMessage, 200, search);
            return Ok(responseDto);
        }

        [HttpGet("get-like-name/{name}")]
        public ActionResult<List<EmployeeDto>> GetLikeName(string name){
            var employee = _employeeService.GetLikeName(name);

            if (employee == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, employee));
            }

            List<string> successMessage = new List<string>();
            successMessage.Add("Lấy thông tin thành công");
            var responseDto = new ResponseDto(successMessage, 200, employee);
            return Ok(responseDto);
        }

        [HttpGet("{id}")]
        public ActionResult<EmployeeDto> GetAEmployee(int id){
            var employee = _employeeService.GetEmployee(id);

            if (employee == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, employee));
            }
            List<string> successMessage = new List<string>();
            successMessage.Add("Lấy thông tin thành công");
            var responseDto = new ResponseDto(successMessage, 200, employee);
            return Ok(responseDto);
        }

        [HttpPost("insert")]
        public ActionResult<EmployeeDto> CreateEmployee([FromBody] EmployeeDto employee){
            employee.RoleId = employee.Role.Id;
            employee.Role = null;
            employee.BirthDate = DateTime.Parse(employee.BirthDate + "");

            var employeeDto = _employeeService.CreateEmployee(employee);

            if (employeeDto == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, employeeDto));
            }

            List<string> successMessage = new List<string>();
            successMessage.Add("Thêm thông tin thành công");
            var responseDto = new ResponseDto(successMessage, 200, employeeDto);
            return Ok(responseDto);
        }

        [HttpPut("update")]
        public ActionResult<EmployeeDto> UpdateEmployee([FromBody] EmployeeDto employee){
            var employeeDto = _employeeService.UpdateEmployee(employee);

            if (employeeDto == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, employeeDto));
            }

            List<string> successMessage = new List<string>();
            successMessage.Add("Sửa thông tin thành công");
            var responseDto = new ResponseDto(successMessage, 200, employeeDto);
            return Ok(responseDto);
        }

        [HttpDelete("delete/{id:int}")]
        public ActionResult<EmployeeDto> DeleteEmployee(int id){
            var employeeDto = _employeeService.DeleteEmployee(id);

            if (employeeDto == null) {
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