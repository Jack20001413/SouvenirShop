using System.Collections.Generic;
using SouvenirShop.Domain.Entities;

namespace Domain.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<Customer> GetAll();
    }
}