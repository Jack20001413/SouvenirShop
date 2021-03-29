using System.Collections.Generic;
using SouvenirShop.Domain.Entities;

namespace Domain.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        IEnumerable<Employee> GetAll();

        Employee GetEmployeeByEmail(string email);
    }
}