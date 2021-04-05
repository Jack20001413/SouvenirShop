using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Application.DTOs;
using SouvenirShop.Application.DTOs;
using System.Collections.Generic;
namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IEmployeeService employeeService;

        public AuthController(IEmployeeService employeeService) {
            this.employeeService = employeeService;
        }

        [HttpPost("login")]
        public ActionResult<ResponseDto> Authenticate(LoginDto loginDto) {
            var response = employeeService.Authenticate(loginDto);

            if (response == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Sai tài khoản hoặc mật khẩu");
                return BadRequest(new ResponseDto(errorMessage, 400, response));
            }
            List<string> successMessage = new List<string>();
            successMessage.Add("Đăng nhập thành công");
            var responseDto = new ResponseDto(successMessage, 200, response);
            return Ok(responseDto);
        }

        [HttpGet("logout")]
        public ActionResult<ResponseDto> Logout()
        {
            HttpContext.Session.Clear();
            List<string> successMessage = new List<string>();
            successMessage.Add("Đăng xuất thành công");
            var responseDto = new ResponseDto(successMessage, 200, "");
            return Ok(responseDto);
        }
    }
}