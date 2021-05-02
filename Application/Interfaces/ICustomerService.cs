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
        BaseSearchDto<CustomerDto> GetAll(BaseSearchDto<CustomerDto> searchDto);
        List<CustomerDto> GetLikeName(string name);
        CustomerDto ChangeAccountState(int id);
        CustomerDto Login(string email, string password);
    }
}