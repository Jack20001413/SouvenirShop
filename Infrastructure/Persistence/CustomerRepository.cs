using System.Collections.Generic;
using System.Linq;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SouvenirShop.Domain.Entities;

namespace Infrastructure.Persistence
{
    public class CustomerRepository : EFRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(SouvenirShopDbContext db) : base(db)
        {
            
        }

        public IEnumerable<Customer> GetAll()
        {
            return _db.Customers.ToList();
        }
    }
}