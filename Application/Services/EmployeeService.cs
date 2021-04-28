using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SouvenirShop.Domain.Entities;
using SouvenirShop.Helpers;

namespace Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IGrantPermissionRepository grantPermissionRepository;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly IRoleRepository _roleRepository;

        public EmployeeService(IEmployeeRepository employeeRepository
                                 ,IMapper mapper
                                 ,IGrantPermissionRepository grantPermissionRepository
                                 ,IOptions<AppSettings> appSettings
                                 ,IRoleRepository roleRepository)
        {
            this.employeeRepository = employeeRepository;
            this.grantPermissionRepository = grantPermissionRepository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _roleRepository = roleRepository;
        }

        public JwtResponseDto Authenticate(LoginDto loginDto)
        {
            // var employee = employeeRepository.GetEmployeeByEmail(loginDto.Username);
            var employee = employeeRepository.GetEmployeeByEmail(loginDto.Username);

            // return null if user not found
            if(employee == null || loginDto.Password != employee.Password){
                return null;
            }

            var employeeFullDto = _mapper.Map<EmployeeFullDto>(employee);
            List<GrantPermission> grantPermissions = (List<GrantPermission>)grantPermissionRepository.GetByRoleId(employeeFullDto.Role.Id);
            var grantPermissionDtos = _mapper.Map<List<GrantPermissionDto>>(grantPermissions);
            employeeFullDto.Role.GrantPermissions = grantPermissionDtos;

            // authentication successful so generate jwt token
            var token = generateJwtToken(employeeFullDto);

            return new JwtResponseDto(employeeFullDto, token);
        }

        public EmployeeDto CreateEmployee(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            int res = employeeRepository.Create(employee);

            if(res <= 0){
                return null;
            }
            return employeeDto;
        }

        public EmployeeDto DeleteEmployee(int id)
        {
            var existed = this.EmployeeExists(id);
            if(!existed){
                return null;
            }
            var employee = employeeRepository.GetById(id);
            int res = employeeRepository.Delete(employee);

            if(res <= 0){
                return null;
            }
            return _mapper.Map<EmployeeDto>(employee);
        }

        public bool EmployeeExists(int id)
        {
            var employee = employeeRepository.GetById(id);
            if(employee == null){
                return false;
            }
            return true;
        }

        public IEnumerable<EmployeeDto> GetAll()
        {
            var employee = employeeRepository.GetAll();
            return _mapper.Map<IEnumerable<EmployeeDto>>(employee);
        }

        public BaseSearchDto<EmployeeDto> GetAll(BaseSearchDto<EmployeeDto> searchDto)
        {
            var employeeSearch = employeeRepository.GetAll(searchDto);

            var roles = _roleRepository.GetAll().ToList();
            foreach (Employee c in employeeSearch.result) {
                c.Role = roles.Where(s => s.Id == c.RoleId).FirstOrDefault();
            }

            BaseSearchDto<EmployeeDto> subCategoryDtoSearch = new BaseSearchDto<EmployeeDto>{
                currentPage = employeeSearch.currentPage,
                recordOfPage = employeeSearch.recordOfPage,
                totalRecords = employeeSearch.totalRecords,
                sortAsc = employeeSearch.sortAsc,
                sortBy = employeeSearch.sortBy,
                createdDateSort = employeeSearch.createdDateSort,
                pagingRange = employeeSearch.pagingRange,
                result = _mapper.Map<List<EmployeeDto>>(employeeSearch.result)
            };
            return subCategoryDtoSearch;
        }

        public EmployeeDto GetEmployee(int id)
        {
            var employee = employeeRepository.GetById(id);
            employee.Role = _roleRepository.GetById(employee.RoleId);
            if(employee == null)
                return null;
            return _mapper.Map<EmployeeDto>(employee);   
        }

        public EmployeeFullDto GetEmployeeFull(string email)
        {
            var employee = employeeRepository.GetEmployeeByEmail(email);
            if(employee == null){
                return null;
            }
            var employeeFullDto = _mapper.Map<EmployeeFullDto>(employee);
            List<GrantPermission> grantPermissions = (List<GrantPermission>)grantPermissionRepository.GetByRoleId(employeeFullDto.Role.Id);
            var grantPermissionDtos = _mapper.Map<List<GrantPermissionDto>>(grantPermissions);
            employeeFullDto.Role.GrantPermissions = grantPermissionDtos;
            return employeeFullDto;
        }

        public List<EmployeeDto> GetLikeName(string name)
        {
            var employees = employeeRepository.GetLikeName(name);
            return _mapper.Map<List<EmployeeDto>>(employees);
        }

        public EmployeeDto UpdateEmployee(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            int res = employeeRepository.Update(employee);

            if(res <= 0){
                return null;
            }
            return employeeDto;
        }

         // helper methods

        private string generateJwtToken(EmployeeFullDto user)
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