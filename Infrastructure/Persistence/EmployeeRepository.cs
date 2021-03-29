using System.Collections.Generic;
using System.Linq;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SouvenirShop.Domain.Entities;

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

        public Employee GetEmployeeByEmail(string email)
        {
            return _db.Employees.Where(s => s.Email == email).Include(s => s.Role).FirstOrDefault();
        }
    }
}