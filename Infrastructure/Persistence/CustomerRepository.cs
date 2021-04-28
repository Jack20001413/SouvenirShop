using System.Collections.Generic;
using System.Linq;
using Application.DTOs;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SouvenirShop.Domain.Entities;
using SouvenirShop.Helpers;

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

        public BaseSearchDto<Customer> GetAll(BaseSearchDto<CustomerDto> search)
        {
            var customerSearch = _db.Customers.Paginate(search.currentPage, search.recordOfPage);

            return new BaseSearchDto<Customer> {
                currentPage = search.currentPage,
                pagingRange = search.pagingRange,
                recordOfPage = search.recordOfPage,
                totalRecords = customerSearch.totalRecords,
                result = customerSearch.result.ToList()
            };
        }

        public List<Customer> GetLikeName(string name)
        {
            var customers = _db.Customers.Where(c => c.Name.Contains(name));
            return customers.ToList();
        }

    }
}