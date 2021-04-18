using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryDto>> GetAll(){
            var categories = _categoryService.GetAll();
            if( categories == null){
                return NotFound("Empty list");
            }
            return Ok(categories);
        }

        [HttpPost("search")]
        public ActionResult<BaseSearchDto<CategoryDto>> GetAll([FromBody] BaseSearchDto<CategoryDto> searchDto) {
            var search = _categoryService.GetAll(searchDto);
            if (search == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, search));
            }
            List<string> successMessage = new List<string>();
            successMessage.Add("Lấy danh mục hàng hoá thành công");
            var responseDto = new ResponseDto(successMessage, 200, search);
            return Ok(responseDto);
        }

        [HttpGet("get-like-name/{name}")]
        public ActionResult<List<CategoryDto>> GetLikeName(string name){
            var categories = _categoryService.GetLikeName(name);

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
        public ActionResult<CategoryDto> GetACategory(int id){
            var category = _categoryService.GetCategory(id);

            if (category == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, category));
            }
            List<string> successMessage = new List<string>();
            successMessage.Add("Lấy thông tin thành công");
            var responseDto = new ResponseDto(successMessage, 200, category);
            return Ok(responseDto);
        }

        [HttpPost("insert")]
        public ActionResult<CategoryDto> CreateCategory([FromBody] CategoryDto category){
            var categoryDto = _categoryService.CreateCategory(category);

            if (categoryDto == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, categoryDto));
            }
            List<string> successMessage = new List<string>();
            successMessage.Add("Thêm thông tin thành công");
            var responseDto = new ResponseDto(successMessage, 200, categoryDto);
            return Ok(responseDto);
        }

        [HttpPut("update")]
        public ActionResult<CategoryDto> UpdateCategory([FromBody] CategoryDto category){
            var categoryDto = _categoryService.UpdateCategory(category);

            if (categoryDto == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, categoryDto));
            }
            List<string> successMessage = new List<string>();
            successMessage.Add("Sửa thông tin thành công");
            var responseDto = new ResponseDto(successMessage, 200, categoryDto);
            return Ok(responseDto);
        }

        [HttpDelete("delete/{id:int}")]
        public ActionResult<CategoryDto> DeleteCategory(int id){
            var categoryDto = _categoryService.DeleteCategory(id);

            if (categoryDto == null) {
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