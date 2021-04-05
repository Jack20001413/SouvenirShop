using System.Collections.Generic;
using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> GetAll(){
            var products = _productService.GetAll();

            if(products == null){
                return NotFound("Empty list");
            }
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetProduct(int id){
            var product = _productService.GetProduct(id);

            if(product == null){
                return NotFound("Unknown item");
            }
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<ProductDto> CreateProduct([FromBody] ProductDto product){
            var obj = _productService.CreateProduct(product);

            if(obj == null){
                return BadRequest("Item was not created!");
            }
            return CreatedAtAction(nameof(GetProduct), new {Id = obj.Id}, obj);
        }

        [HttpPut]
        public ActionResult<ProductDto> UpdateProduct([FromBody] ProductDto product){
            var obj = _productService.UpdateProduct(product);

            if(obj == null){
                return NotFound("Unknown item");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<ProductDto> DeleteProduct(int id){
            var obj = _productService.DeleteProduct(id);

            if(obj == null){
                return NotFound("Unknown item");
            }
            return NoContent();
        }
    }
}