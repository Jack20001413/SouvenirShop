using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SouvenirShop.Domain.Entities;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SupplierDto>> GetAll(){
            var suppliers = _supplierService.GetAll();
            if( suppliers == null){
                return NotFound("Empty list");
            }
            return Ok(suppliers);
        }

        [HttpPost("search")]
        public ActionResult<BaseSearchDto<SupplierDto>> GetAll([FromBody] BaseSearchDto<SupplierDto> searchDto) {
            var search = _supplierService.GetAll(searchDto);

            if (search == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, search));
            }
            
            List<string> successMessage = new List<string>();
            successMessage.Add("Lấy danh sách nhà cung cấp thành công");
            var responseDto = new ResponseDto(successMessage, 200, search);
            return Ok(responseDto);
        }

        [HttpGet("get-like-name/{name}")]
        public ActionResult<List<SupplierDto>> GetLikeName(string name){
            var subCategories = _supplierService.GetLikeName(name);

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
        public ActionResult<SupplierDto> GetASupplier(int id){
            var supplier = _supplierService.GetSupplier(id);

            if (supplier == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, supplier));
            }
            List<string> successMessage = new List<string>();
            successMessage.Add("Lấy thông tin thành công");
            var responseDto = new ResponseDto(successMessage, 200, supplier);
            return Ok(responseDto);
        }

        [HttpPost("insert")]
        public ActionResult<SupplierDto> CreateSupplier([FromBody] SupplierDto supplier){
            var supplierDto = _supplierService.CreateSupplier(supplier);

            if (supplierDto == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, supplierDto));
            }
            List<string> successMessage = new List<string>();
            successMessage.Add("Thêm thông tin thành công");
            var responseDto = new ResponseDto(successMessage, 200, supplierDto);
            return Ok(responseDto);
        }

        [HttpPut("update")]
        public ActionResult<SupplierDto> UpdateSupplier([FromBody] SupplierDto supplier){
            var supplierDto = _supplierService.UpdateSupplier(supplier);

            if (supplierDto == null) {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Đã phát sinh lỗi, vui lòng thử lại");
                return BadRequest(new ResponseDto(errorMessage, 500, supplierDto));
            }
            List<string> successMessage = new List<string>();
            successMessage.Add("Sửa thông tin thành công");
            var responseDto = new ResponseDto(successMessage, 200, supplierDto);
            return Ok(responseDto);
        }

        [HttpDelete("delete/{id:int}")]
        public ActionResult<SupplierDto> DeleteSupplier(int id){
            var supplierDto = _supplierService.DeleteSupplier(id);

            if (supplierDto == null) {
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