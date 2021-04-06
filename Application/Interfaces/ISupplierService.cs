using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface ISupplierService
    {
        IEnumerable<SupplierDto> GetAll();
        SupplierDto GetSupplier(int id);
        SupplierDto CreateSupplier(SupplierDto supplierDto);
        SupplierDto UpdateSupplier(SupplierDto supplierDto);
        SupplierDto DeleteSupplier(int id);
         bool SupplierExists(int id); 
    }
}