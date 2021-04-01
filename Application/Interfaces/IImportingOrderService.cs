using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IImportingOrderService
    {
        IEnumerable<ImportingOrderDto> GetAll();
        ImportingOrderDto GetImportingOrder(int id);
         void CreateImportingOrder(ImportingOrderDto order);
         void UpdateImportingOrder(ImportingOrderDto order);
         void DeleteImportingOrder(ImportingOrderDto order);
         bool ImportingOrderExists(int id); 
    }
}