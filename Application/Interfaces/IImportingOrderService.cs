using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IImportingOrderService
    {
        IEnumerable<ImportingOrderDto> GetAll();
        ImportingOrderDto GetImportingOrder(int id);
        ImportingOrderDto CreateImportingOrder(ImportingOrderDto orderDto);
        ImportingOrderDto UpdateImportingOrder(ImportingOrderDto orderDto);
        ImportingOrderDto DeleteImportingOrder(int id);
        bool ImportingOrderExists(int id); 
        BaseSearchDto<ImportingOrderDto> GetAll(BaseSearchDto<ImportingOrderDto> searchDto);
    }
}