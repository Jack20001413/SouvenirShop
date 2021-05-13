using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("get-all")]
        public ActionResult<IEnumerable<ProductDto>> GetAll(){
            var products = _productService.GetAll();

            if( products == null){
                 List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, products));
            }

            List<string> successMessage = new List<string>();
            successMessage.Add("Lấy danh mục con hàng hoá thành công");
            var responseDto = new ResponseDto(successMessage, 200, products);
            return Ok(responseDto);
        }

        [HttpPost("search")]
        public ActionResult<BaseSearchDto<ProductDto>> GetAll([FromBody] BaseSearchDto<ProductDto> searchDto) {
            var search = _productService.GetAll(searchDto);

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

        [HttpGet("get-like-name/{name}")]
        public ActionResult<List<ProductDto>> GetLikeName(string name){
            var products = _productService.GetLikeName(name);

            if (products == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, products));
            }

            List<string> successMessage = new List<string>();
            successMessage.Add("Lấy thông tin thành công");
            var responseDto = new ResponseDto(successMessage, 200, products);
            return Ok(responseDto);
        }

        // [HttpGet("{id}")]
        // public ActionResult<ProductDto> GetAProduct(int id){
        //     var product = _productService.GetProduct(id);

        //     if (product == null) {
        //         List<string> errorMessage = new List<string>();
        //         errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
        //         return BadRequest(new ResponseDto(errorMessage, 500, product));
        //     }

        //     List<string> successMessage = new List<string>();
        //     successMessage.Add("Lấy thông tin thành công");
        //     var responseDto = new ResponseDto(successMessage, 200, product);
        //     return Ok(responseDto);
        // }

        [HttpGet("get-full/{id}")]
        public ActionResult<ProductFullDto> GetProductFull(int id){
            var product = _productService.GetProductFull(id);

            if (product == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, product));
            }

            List<string> successMessage = new List<string>();
            successMessage.Add("Lấy thông tin thành công");
            var responseDto = new ResponseDto(successMessage, 200, product);
            return Ok(responseDto);
        }

        [HttpPost("insert")]
        public ActionResult<ProductDto> CreateProduct([FromBody] ProductDto product){
            product.SubCategoryId = product.SubCategory.Id;
            product.SubCategory = null;

            var productDto = _productService.CreateProduct(product);

            if (productDto == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, productDto));
            }

            List<string> successMessage = new List<string>();
            successMessage.Add("Thêm thông tin thành công");
            var responseDto = new ResponseDto(successMessage, 200, productDto);
            return Ok(responseDto);
        }

        [HttpPut("update")]
        public ActionResult<ProductDto> UpdateProduct([FromBody] ProductDto product){
            product.SubCategoryId = product.SubCategory.Id;
            product.SubCategory = null;
            
            var productDto = _productService.UpdateProduct(product);

            if (productDto == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, productDto));
            }

            List<string> successMessage = new List<string>();
            successMessage.Add("Sửa thông tin thành công");
            var responseDto = new ResponseDto(successMessage, 200, productDto);
            return Ok(responseDto);
        }

        [HttpDelete("delete/{id:int}")]
        public ActionResult<ProductDto> DeleteProduct(int id){
            var productDto = _productService.DeleteProduct(id);

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

        [HttpGet("get-list/{id:int}")]
        public ActionResult<IEnumerable<ProductDto>> GetList(int id){
            var productDtos = _productService.GetList(id);

            if (productDtos == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, productDtos));
            }

            List<string> successMessage = new List<string>();
            successMessage.Add("Lấy danh sách sản phẩm thành công");
            var responseDto = new ResponseDto(successMessage, 200, productDtos);
            return Ok(responseDto);
        }

        [HttpGet("get-list-by-category/{id:int}")]
        public ActionResult<IEnumerable<ProductDto>> GetListByCategory(int id){
            var productDtos = _productService.GetListByCategory(id);

            if (productDtos == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, productDtos));
            }

            List<string> successMessage = new List<string>();
            successMessage.Add("Lấy danh sách sản phẩm thành công");
            var responseDto = new ResponseDto(successMessage, 200, productDtos);
            return Ok(responseDto);
        }
    }
}