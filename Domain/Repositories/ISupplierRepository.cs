using System.Collections.Generic;
using Application.DTOs;
using SouvenirShop.Domain.Entities;

namespace Domain.Repositories
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        IEnumerable<Supplier> GetAll();
        BaseSearchDto<Supplier> GetAll(BaseSearchDto<SupplierDto> searchDto);
        List<Supplier> GetLikeName(string name);
    }
}