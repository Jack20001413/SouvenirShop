using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryService _subCategoryService;

        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SubCategoryDto>> GetAll(){
            var subCategories = _subCategoryService.GetAll();
            if( subCategories == null){
                return NotFound("Empty list");
            }
            return Ok(subCategories);
        }

        [HttpPost("search")]
        public ActionResult<BaseSearchDto<SubCategoryDto>> GetAll([FromBody] BaseSearchDto<SubCategoryDto> searchDto) {
            var search = _subCategoryService.GetAll(searchDto);
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
        public ActionResult<List<SubCategoryDto>> GetLikeName(string name){
            var subCategories = _subCategoryService.GetLikeName(name);

            if (subCategories == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, subCategories));
            }
            List<string> successMessage = new List<string>();
            successMessage.Add("Lấy thông tin thành công");
            var responseDto = new ResponseDto(successMessage, 200, subCategories);
            return Ok(responseDto);
        }

        [HttpGet("{id}")]
        public ActionResult<SubCategoryDto> GetASubCategory(int id){
            var subCategory = _subCategoryService.GetSubCategory(id);

            if (subCategory == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, subCategory));
            }
            List<string> successMessage = new List<string>();
            successMessage.Add("Lấy thông tin thành công");
            var responseDto = new ResponseDto(successMessage, 200, subCategory);
            return Ok(responseDto);
        }

        [HttpPost("insert")]
        public ActionResult<SubCategoryDto> CreateSubCategory([FromBody] SubCategoryDto subCategory){
            subCategory.CategoryId = subCategory.Category.Id;
            subCategory.Category = null;
            var subCategoryDto = _subCategoryService.CreateSubCategory(subCategory);

            if (subCategoryDto == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, subCategoryDto));
            }
            List<string> successMessage = new List<string>();
            successMessage.Add("Thêm thông tin thành công");
            var responseDto = new ResponseDto(successMessage, 200, subCategoryDto);
            return Ok(responseDto);
        }

        [HttpPut("update")]
        public ActionResult<SubCategoryDto> UpdateSubCategory([FromBody] SubCategoryDto subCategory){
            var subCategoryDto = _subCategoryService.UpdateSubCategory(subCategory);

            if (subCategoryDto == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, subCategoryDto));
            }
            List<string> successMessage = new List<string>();
            successMessage.Add("Sửa thông tin thành công");
            var responseDto = new ResponseDto(successMessage, 200, subCategoryDto);
            return Ok(responseDto);
        }

        [HttpDelete("delete/{id:int}")]
        public ActionResult<SubCategoryDto> DeleteSubCategory(int id){
            var subCategoryDto = _subCategoryService.DeleteSubCategory(id);

            if (subCategoryDto == null) {
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