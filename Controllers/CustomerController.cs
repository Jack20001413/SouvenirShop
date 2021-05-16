using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CustomerDto>> GetAll(){
            var customers = _customerService.GetAll();

            if( customers == null){
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return NotFound(new ResponseDto(errorMessage, 500, customers));
            }

            List<string> successMessage = new List<string>();
            successMessage.Add("Lấy danh mục khách hàng thành công");
            var responseDto = new ResponseDto(successMessage, 200, customers);
            return Ok(responseDto);
        }

        [HttpPost("search")]
        public ActionResult<BaseSearchDto<CustomerDto>> GetAll([FromBody] BaseSearchDto<CustomerDto> searchDto) {
            var search = _customerService.GetAll(searchDto);
            if (search == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, search));
            }
            List<string> successMessage = new List<string>();
            successMessage.Add("Lấy danh mục khách hàng thành công");
            var responseDto = new ResponseDto(successMessage, 200, search);
            return Ok(responseDto);
        }

        [HttpGet("get-like-name/{name}")]
        public ActionResult<List<CustomerDto>> GetLikeName(string name){
            var customers = _customerService.GetLikeName(name);

            if (customers == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return NotFound(new ResponseDto(errorMessage, 500, customers));
            }
            List<string> successMessage = new List<string>();
            successMessage.Add("Lấy thông tin thành công");
            var responseDto = new ResponseDto(successMessage, 200, customers);
            return Ok(responseDto);
        }

        [HttpGet("{id}")]
        public ActionResult<CustomerDto> GetACustomer(int id){
            var customer = _customerService.GetCustomer(id);

            if (customer == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return NotFound(new ResponseDto(errorMessage, 500, customer));
            }
            List<string> successMessage = new List<string>();
            successMessage.Add("Lấy thông tin thành công");
            var responseDto = new ResponseDto(successMessage, 200, customer);
            return Ok(responseDto);
        }

        [HttpPost("insert")]
        public ActionResult<CustomerDto> CreateCustomer([FromBody] CustomerDto customer){
            customer.IsValid = true;
            var customerDto = _customerService.CreateCustomer(customer);

            if (customerDto == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, customerDto));
            }
            List<string> successMessage = new List<string>();
            successMessage.Add("Thêm thông tin thành công");
            var responseDto = new ResponseDto(successMessage, 200, customerDto);
            return CreatedAtAction(nameof(GetAll) ,responseDto);
        }

        [HttpPut("update")]
        public ActionResult<CustomerDto> UpdateCustomer([FromBody] CustomerDto customer){
            var customerDto = _customerService.UpdateCustomer(customer);

            if (customerDto == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return NotFound(new ResponseDto(errorMessage, 500, customerDto));
            }
            List<string> successMessage = new List<string>();
            successMessage.Add("Sửa thông tin thành công");
            var responseDto = new ResponseDto(successMessage, 200, customerDto);
            return Ok(responseDto);
        }

        [HttpDelete("delete/{id:int}")]
        public ActionResult<CustomerDto> DeleteCustomer(int id){
            var customerDto = _customerService.DeleteCustomer(id);

            if (customerDto == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return NotFound(new ResponseDto(errorMessage, 500, ""));
            }
            List<string> successMessage = new List<string>();
            successMessage.Add("Xoá thành công");
            var responseDto = new ResponseDto(successMessage, 200, "");
            return Ok(responseDto);
        }

        [HttpPut("change-account-state")]
        public ActionResult<CustomerDto> ChangeAccountState([FromBody] CustomerDto customer){
            var customerDto = _customerService.ChangeAccountState(customer.Id);

            if(customerDto == null){
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return NotFound(new ResponseDto(errorMessage, 500, ""));
            }
            List<string> successMessage = new List<string>();
            successMessage.Add("Thay đổi trạng thái thành công");
            var responseDto = new ResponseDto(successMessage, 200, "");
            return Ok(responseDto);
        }

        [HttpPost("login")]
        public ActionResult<CustomerDto> Login([FromBody] LoginDto login){
            var response = _customerService.Login(login.Username, login.Password);

            if(response == null){
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Tài khoản hoặc mật khẩu không hợp lệ, vui lòng thử lại");
                return Ok(new ResponseDto(errorMessage, 500, response));
            }

            List<string> successMessage = new List<string>();
            successMessage.Add("Đăng nhập thành công");
            var responseDto = new ResponseDto(successMessage, 200, response);
            return Ok(responseDto);
        }
    }
}