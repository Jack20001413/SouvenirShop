using System.Collections.Generic;
using System.Linq;
using Application.DTOs;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SouvenirShop.Domain.Entities;
using SouvenirShop.Helpers;

namespace Infrastructure.Persistence
{
    public class EmployeeRepository : EFRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(SouvenirShopDbContext db) : base(db)
        {
        }

        public IEnumerable<Employee> GetAll()
        {
            return _db.Employees.Include(e => e.Role).ToList();
        }

        public BaseSearchDto<Employee> GetAll(BaseSearchDto<EmployeeDto> search)
        {
            var employeeSearch = _db.Employees.Paginate(search.currentPage, search.recordOfPage);

            return new BaseSearchDto<Employee> {
                currentPage = search.currentPage,
                pagingRange = search.pagingRange,
                recordOfPage = search.recordOfPage,
                totalRecords = employeeSearch.totalRecords,
                result = employeeSearch.result.ToList()
            };
        }

        public Employee GetEmployeeByEmail(string email)
        {
            return _db.Employees.Where(s => s.Email == email).Include(s => s.Role).FirstOrDefault();
        }

        public List<Employee> GetLikeName(string name)
        {
            var employees = _db.Employees.Where(c => c.Name.Contains(name));
            return employees.ToList();
        }
    }
}