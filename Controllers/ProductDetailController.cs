using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;



namespace Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductDetailService _productdetailService;

        public ProductDetailController(IProductDetailService productdetailService)
        {
            _productdetailService = productdetailService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDetailDto>> GetAll(){
            var productdetails = _productdetailService.GetAll();

            if( productdetails == null){
                 List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, productdetails));
            }
            

            List<string> successMessage = new List<string>();
            successMessage.Add("Lấy danh mục con hàng hoá thành công");
            var responseDto = new ResponseDto(successMessage, 200, productdetails);
            return Ok(responseDto);
        }

        [HttpPost("search")]
        public ActionResult<BaseSearchDto<ProductDetailDto>> GetAll([FromBody] BaseSearchDto<ProductDetailDto> searchDto) {
            var search = _productdetailService.GetAll(searchDto);

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
        public ActionResult<ProductDetailDto> GetAProductDetail(int id){
            var productdetails = _productdetailService.GetProductDetail(id);

            if (productdetails == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, productdetails));
            }

            List<string> successMessage = new List<string>();
            successMessage.Add("Lấy thông tin thành công");
            var responseDto = new ResponseDto(successMessage, 200, productdetails);
            return Ok(responseDto);
        }

        [HttpPost("insert")]
        public ActionResult<ProductDetailDto> CreateProductDetail([FromBody] ProductDetailDto productdetail){
            productdetail.SizeId = productdetail.Size.Id;
            productdetail.Size = null;
            productdetail.ColorId = productdetail.Color.Id;
            productdetail.Color = null;
            productdetail.ProductId = productdetail.Product.Id;
            productdetail.Product = null;

            var productdetailDto = _productdetailService.CreateProductDetail(productdetail);

            if (productdetailDto == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, productdetailDto));
            }

            List<string> successMessage = new List<string>();
            successMessage.Add("Thêm thông tin thành công");
            var responseDto = new ResponseDto(successMessage, 200, productdetailDto);
            return Ok(responseDto);
        }

        [HttpPut("update")]
        public ActionResult<ProductDetailDto> UpdateProductDetail([FromBody] ProductDetailDto productdetail){
            productdetail.SizeId = productdetail.Size.Id;
            productdetail.Size = null;
            productdetail.ColorId = productdetail.Color.Id;
            productdetail.Color = null;
            productdetail.ProductId = productdetail.Product.Id;
            productdetail.Product = null;
            
            var productdetailDto = _productdetailService.UpdateProductDetail(productdetail);

            if (productdetailDto == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, productdetailDto));
            }

            List<string> successMessage = new List<string>();
            successMessage.Add("Sửa thông tin thành công");
            var responseDto = new ResponseDto(successMessage, 200, productdetailDto);
            return Ok(responseDto);
        }

        [HttpDelete("delete/{id:int}")]
        public ActionResult<ProductDetailDto> DeleteProductDetail(int id){
            var productDto = _productdetailService.DeleteProductDetail(id);

            if (productDto == null) {
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