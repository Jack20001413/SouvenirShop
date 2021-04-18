using System.Collections.Generic;
using Application.DTOs;
using SouvenirShop.Domain.Entities;

namespace Domain.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        IEnumerable<Employee> GetAll();

        Employee GetEmployeeByEmail(string email);
        BaseSearchDto<Employee> GetAll(BaseSearchDto<EmployeeDto> search);
        List<Employee> GetLikeName(string name);
    }
}