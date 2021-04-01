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