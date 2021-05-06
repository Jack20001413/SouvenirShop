using System.Collections.Generic;
using Application.DTOs;
using Infrastructure.Persistence;
using SouvenirShop.Domain.Entities;

namespace Domain.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<Customer> GetAll();
        BaseSearchDto<Customer> GetAll(BaseSearchDto<CustomerDto> search);
        List<Customer> GetLikeName(string name);
    }
}