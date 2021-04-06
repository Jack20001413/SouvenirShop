using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDto> GetAll();
        CustomerDto GetCustomer(int id);
        CustomerDto CreateCustomer(CustomerDto customerDto);
        CustomerDto UpdateCustomer(CustomerDto customerDto);
        CustomerDto DeleteCustomer(int id);
        bool CustomerExists(int id); 
    }
}