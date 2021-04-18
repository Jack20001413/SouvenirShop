using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetAll();
        JwtResponseDto Authenticate(LoginDto loginDto);
        EmployeeDto GetEmployee(int id);
        EmployeeDto CreateEmployee(EmployeeDto employeeDto);
        EmployeeDto UpdateEmployee(EmployeeDto employeeDto);
        EmployeeDto DeleteEmployee(int id);
        bool EmployeeExists(int id); 
        BaseSearchDto<EmployeeDto> GetAll(BaseSearchDto<EmployeeDto> searchDto);
        List<EmployeeDto> GetLikeName(string name);
    }
}