using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColorController : ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ColorDto>> GetAll(){
            var colors = _colorService.GetAll();
            if( colors == null){
                return NotFound("Empty list");
            }
            return Ok(colors);
        }

        [HttpPost("search")]
        public ActionResult<BaseSearchDto<ColorDto>> GetAll([FromBody] BaseSearchDto<ColorDto> searchDto) {
            var search = _colorService.GetAll(searchDto);
            if (search == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, search));
            }
            List<string> successMessage = new List<string>();
            successMessage.Add("Lấy danh sách màu sắc thành công");
            var responseDto = new ResponseDto(successMessage, 200, search);
            return Ok(responseDto);
        }

        [HttpGet("{id}")]
        public ActionResult<ColorDto> GetAColor(int id){
            var color = _colorService.GetColor(id);

            if (color == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, color));
            }
            List<string> successMessage = new List<string>();
            successMessage.Add("Lấy thông tin thành công");
            var responseDto = new ResponseDto(successMessage, 200, color);
            return Ok(responseDto);
        }

        [HttpPost("insert")]
        public ActionResult<ColorDto> CreateColor([FromBody] ColorDto color){
            var colorDto = _colorService.CreateColor(color);

            if (colorDto == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, colorDto));
            }
            List<string> successMessage = new List<string>();
            successMessage.Add("Thêm màu sắc thành công");
            var responseDto = new ResponseDto(successMessage, 200, colorDto);
            return Ok(responseDto);
        }

        [HttpPut("update")]
        public ActionResult<ColorDto> UpdateColor([FromBody] ColorDto color){
            var colorDto = _colorService.UpdateColor(color);

            if (colorDto == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, colorDto));
            }
            List<string> successMessage = new List<string>();
            successMessage.Add("Sửa thông tin thành công");
            var responseDto = new ResponseDto(successMessage, 200, colorDto);
            return Ok(responseDto);
        }

        [HttpDelete("delete/{id:int}")]
        public ActionResult<ColorDto> DeleteColor(int id){
            var colorDto = _colorService.DeleteColor(id);

            if (colorDto == null) {
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