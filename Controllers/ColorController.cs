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

            if( color == null){
                return NotFound();
            }
            return Ok(color);
        }

        [HttpPost]
        public ActionResult<ColorDto> CreateColor([FromBody] ColorDto color){
            var obj = _colorService.CreateColor(color);

            if(obj == null){
                return BadRequest("Item was not added");
            }
            return CreatedAtAction(nameof(GetAColor), new {Id = obj.Id}, obj);
        }

        [HttpPut]
        public ActionResult<ColorDto> UpdateColor([FromBody] ColorDto color){
            var obj = _colorService.UpdateColor(color);

            if(obj == null){
                return NotFound("Unknown item");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<ColorDto> DeleteColor(int id){
            var obj = _colorService.DeleteColor(id);

            if(obj == null){
                return NotFound("Unknown item");
            }
            return NoContent();
        }
    }
}