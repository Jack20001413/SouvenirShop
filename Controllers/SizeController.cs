using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SizeController : ControllerBase
    {
        private readonly ISizeService _sizeService;

        public SizeController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SizeDto>> GetAll(){
            var colors = _sizeService.GetAll();
            if( colors == null){
                return NotFound("Empty list");
            }
            return Ok(colors);
        }

        [HttpPost("search")]
        public ActionResult<BaseSearchDto<SizeDto>> GetAll([FromBody] BaseSearchDto<SizeDto> searchDto) {
            var search = _sizeService.GetAll(searchDto);
            if (search == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, search));
            }
            List<string> successMessage = new List<string>();
            successMessage.Add("Lấy danh sách kích thước thành công");
            var responseDto = new ResponseDto(successMessage, 200, search);
            return Ok(responseDto);
        }

        [HttpGet("{id}")]
        public ActionResult<SizeDto> GetASize(int id){
            var size = _sizeService.GetSize(id);

            if (size == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, size));
            }
            List<string> successMessage = new List<string>();
            successMessage.Add("Lấy thông tin thành công");
            var responseDto = new ResponseDto(successMessage, 200, size);
            return Ok(responseDto);
        }

        [HttpPost("insert")]
        public ActionResult<SizeDto> CreateSize([FromBody] SizeDto size){
            var sizeDto = _sizeService.CreateSize(size);

            if (sizeDto == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, sizeDto));
            }
            List<string> successMessage = new List<string>();
            successMessage.Add("Thêm thông tin thành công");
            var responseDto = new ResponseDto(successMessage, 200, sizeDto);
            return Ok(responseDto);
        }

        [HttpPut("update")]
        public ActionResult<SizeDto> UpdateSize([FromBody] SizeDto size){
            var sizeDto = _sizeService.UpdateSize(size);

            if (sizeDto == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, sizeDto));
            }
            List<string> successMessage = new List<string>();
            successMessage.Add("Sửa thông tin thành công");
            var responseDto = new ResponseDto(successMessage, 200, sizeDto);
            return Ok(responseDto);
        }

        [HttpDelete("delete/{id:int}")]
        public ActionResult<SizeDto> DeleteSize(int id){
            var sizeDto = _sizeService.DeleteSize(id);

            if (sizeDto == null) {
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