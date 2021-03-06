using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SellingOrderController : ControllerBase
    {
        private readonly ISellingOrderService _orderService;

        public SellingOrderController(ISellingOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SellingOrderDto>> GetAll(){
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
        public ActionResult<BaseSearchDto<SellingOrderDto>> GetAll([FromBody] BaseSearchDto<SellingOrderDto> searchDto) {
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
        public ActionResult<SellingOrderDto> GetASellingOrder(int id){
            var order = _orderService.GetSellingOrder(id);

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
        public ActionResult<SellingOrderDto> CreateSellingOrder([FromBody] SellingOrderDto order){
            order.CustomerId = order.Customer.Id;
            order.Customer = null;
            foreach(SellingTransactionDto tran in order.SellingTransactions){
                tran.ProductDetailId = tran.ProductDetail.Id;
                tran.ProductDetail = null;
            }

            var orderDto = _orderService.CreateSellingOrder(order);

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
        public ActionResult<SellingOrderDto> UpdateSellingOrder([FromBody] SellingOrderDto order){
            var orderDto = _orderService.UpdateSellingOrder(order);

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
        public ActionResult<SellingOrderDto> DeleteSellingOrder(int id){
            var order = _orderService.DeleteSellingOrder(id);

            if (order == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, ""));
            }
            
            List<string> successMessage = new List<string>();
            successMessage.Add("Xoá thành công");
            var responseDto = new ResponseDto(successMessage, 200, "");
            return Ok(responseDto);
        }

        [HttpGet("get-transaction-by-order-id/{id:int}")]
        public ActionResult<IEnumerable<SellingTransactionDto>> GetSellingTransactionByOrderId(int id){
            var transactions = _orderService.GetSellingTransactionByOrderId(id);

            if (transactions == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, transactions));
            }
            
            List<string> successMessage = new List<string>();
            successMessage.Add("Xoá thành công");
            var responseDto = new ResponseDto(successMessage, 200, transactions);
            return Ok(responseDto);
        }

        [HttpGet("get-by-customer-id/{id:int}")]
        public ActionResult<IEnumerable<SellingOrderDto>> GetSellingOrderByCustomerId(int id){
            var orders = _orderService.GetSellingOrderByCustomerId(id);

            if (orders == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, orders));
            }
            
            List<string> successMessage = new List<string>();
            successMessage.Add("Xoá thành công");
            var responseDto = new ResponseDto(successMessage, 200, orders);
            return Ok(responseDto);
        }

        [HttpPost("payment")]
        public ActionResult<OrderPaymentIntentDto> Payment([FromBody] PaymentInputDto paymentInput){
            var orderPaymentIntent = _orderService.CreatePaymentIntent(paymentInput.OrderId);
            if (orderPaymentIntent == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, orderPaymentIntent));
            }

            List<string> successMessage = new List<string>();
            successMessage.Add("Thêm thông tin thành công");
            var responseDto = new ResponseDto(successMessage, 200, orderPaymentIntent);
            return Ok(responseDto);
        }

        [HttpPost("get-month-cost")]
        public ActionResult<SellingOrderDto> GetMonthCostDetails([FromBody] RangeDateDto rangeDate){
            var monthCostDetails = _orderService.getMonthCostDetails(rangeDate);

            if (monthCostDetails == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, monthCostDetails));
            }
            List<string> successMessage = new List<string>();
            successMessage.Add("Lấy dữ liệu thành công");
            var responseDto = new ResponseDto(successMessage, 200, monthCostDetails);
            return Ok(responseDto);
        }
    }
}