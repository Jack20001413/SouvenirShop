using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface ISupplierService
    {
        IEnumerable<SupplierDto> GetAll();
        SupplierDto GetSupplier(int id);
         void CreateSupplier(SupplierDto supplier);
         void UpdateSupplier(SupplierDto supplier);
         void DeleteSupplier(SupplierDto supplier);
         bool SupplierExists(int id); 
    }
}