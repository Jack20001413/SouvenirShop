using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Repositories;
using Microsoft.IdentityModel.Tokens;
using SouvenirShop.Domain.Entities;
using System;
namespace Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repo;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            int res = _repo.Create(customer);

            if(res <= 0){
                return null;
            }
            return customerDto;
        }

        public bool CustomerExists(int id)
        {
            var customer = _repo.GetById(id);
            if(customer == null){
                return false;
            }
            return true;
        }

        public CustomerDto DeleteCustomer(int id)
        {
            var existed = this.CustomerExists(id);
            if(!existed){
                return null;
            }
            var customer = _repo.GetById(id);
            int res = _repo.Delete(customer);

            if(res <= 0){
                return null;
            }
            return _mapper.Map<CustomerDto>(customer);
        }

        public IEnumerable<CustomerDto> GetAll()
        {
            var customers = _repo.GetAll();
            return _mapper.Map<IEnumerable<CustomerDto>>(customers);
        }

        public BaseSearchDto<CustomerDto> GetAll(BaseSearchDto<CustomerDto> searchDto)
        {
            var customerSearch = _repo.GetAll(searchDto);

            BaseSearchDto<CustomerDto> customerDtoSearch = new BaseSearchDto<CustomerDto>{
                currentPage = customerSearch.currentPage,
                recordOfPage = customerSearch.recordOfPage,
                totalRecords = customerSearch.totalRecords,
                sortAsc = customerSearch.sortAsc,
                sortBy = customerSearch.sortBy,
                createdDateSort = customerSearch.createdDateSort,
                pagingRange = customerSearch.pagingRange,
                result = _mapper.Map<List<CustomerDto>>(customerSearch.result)
            };
            return customerDtoSearch;
        }

        public CustomerDto GetCustomer(int id)
        {
            var customer = _repo.GetById(id);
            return _mapper.Map<CustomerDto>(customer);
        }

        public List<CustomerDto> GetLikeName(string name)
        {
            var customers = _repo.GetLikeName(name);
            return _mapper.Map<List<CustomerDto>>(customers);
        }

        public CustomerDto UpdateCustomer(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            int res = _repo.Update(customer);

            if(res <= 0){
                return null;
            }
            return customerDto;
        }

        public CustomerDto ChangeAccountState(int id)
        {
            var customer = _repo.GetById(id);

            if(customer.IsValid == false){
                customer.IsValid = true;
            }else{
                customer.IsValid = false;
            }

            int res = _repo.Update(customer);

            if(res <= 0){
                return null;
            }
            return _mapper.Map<CustomerDto>(customer);
        }

        public JwtResponseDto Login(string email, string password){
            var customer = _repo.Login(email, password);

             // var employee = employeeRepository.GetEmployeeByEmail(loginDto.Username);
            // return null if user not found
            if(customer == null || !customer.IsValid){
                return null;
            }

            var customerDto = _mapper.Map<CustomerDto>(customer);


            // authentication successful so generate jwt token
            var token = generateJwtToken(customer);

            return new JwtResponseDto(customerDto, token);
        }

        private string generateJwtToken(Customer user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("This is Secret Key of Pun's House so dont share it desu ne");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}