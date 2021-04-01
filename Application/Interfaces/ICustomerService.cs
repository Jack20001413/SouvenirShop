using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDto> GetAll();
        CustomerDto GetCustomer(int id);
         void CreateCustomer(CustomerDto employee);
         void UpdateCustomer(CustomerDto employee);
         void DeleteCustomer(CustomerDto employee);
         bool CustomerExists(int id); 
    }
}