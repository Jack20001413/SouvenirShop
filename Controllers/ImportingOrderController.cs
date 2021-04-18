using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImportingOrderController : ControllerBase
    {
        private readonly IImportingOrderService _orderService;

        public ImportingOrderController(IImportingOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ImportingOrderDto>> GetAll(){
            var orders = _orderService.GetAll();

            if( orders == null){
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, orders));
            }

            List<string> successMessage = new List<string>();
            successMessage.Add("Lấy danh mục con hàng hoá thành công");
            var responseDto = new ResponseDto(successMessage, 200, orders);
            return Ok(responseDto);
        }

        [HttpPost("search")]
        public ActionResult<BaseSearchDto<ImportingOrderDto>> GetAll([FromBody] BaseSearchDto<ImportingOrderDto> searchDto) {
            var search = _orderService.GetAll(searchDto);

            if (search == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, search));
            }

            List<string> successMessage = new List<string>();
            successMessage.Add("Lấy danh mục con hàng hoá thành công");
            var responseDto = new ResponseDto(successMessage, 200, search);
            return Ok(responseDto);
        }

        [HttpGet("{id}")]
        public ActionResult<ImportingOrderDto> GetAnOrder(int id){
            var order = _orderService.GetImportingOrder(id);

            if (order == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, order));
            }
            
            List<string> successMessage = new List<string>();
            successMessage.Add("Lấy thông tin thành công");
            var responseDto = new ResponseDto(successMessage, 200, order);
            return Ok(responseDto);
        }

        [HttpPost("insert")]
        public ActionResult<ImportingOrderDto> CreateImportingOrder([FromBody] ImportingOrderDto order){
            order.SupplierId = order.Supplier.Id;
            order.Supplier = null;

            order.EmployeeId = order.Employee.Id;
            order.Employee = null;

            var orderDto = _orderService.CreateImportingOrder(order);

            if (orderDto == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, orderDto));
            }

            List<string> successMessage = new List<string>();
            successMessage.Add("Thêm thông tin thành công");
            var responseDto = new ResponseDto(successMessage, 200, orderDto);
            return Ok(responseDto);
        }

        [HttpPut("update")]
        public ActionResult<ImportingOrderDto> UpdateImportingOrder([FromBody] ImportingOrderDto order){
            var orderDto = _orderService.UpdateImportingOrder(order);

            if (orderDto == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, orderDto));
            }

            List<string> successMessage = new List<string>();
            successMessage.Add("Sửa thông tin thành công");
            var responseDto = new ResponseDto(successMessage, 200, orderDto);
            return Ok(responseDto);
        }

        [HttpDelete("delete/{id:int}")]
        public ActionResult<ImportingOrderDto> DeleteImportingOrder(int id){
            var orderDto = _orderService.DeleteImportingOrder(id);

            if (orderDto == null) {
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