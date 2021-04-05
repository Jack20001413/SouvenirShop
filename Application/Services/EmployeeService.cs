using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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

        public EmployeeService(IEmployeeRepository employeeRepository
                                 ,IMapper mapper
                                 ,IGrantPermissionRepository grantPermissionRepository
                                 ,IOptions<AppSettings> appSettings)
        {
            this.employeeRepository = employeeRepository;
            this.grantPermissionRepository = grantPermissionRepository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
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

        public void CreateEmployee(EmployeeDto brand)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteEmployee(EmployeeDto brand)
        {
            throw new System.NotImplementedException();
        }

        public bool EmployeeExists(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<EmployeeDto> GetAll()
        {
            var employee = employeeRepository.GetAll();
            return _mapper.Map<IEnumerable<EmployeeDto>>(employee);
        }

        public EmployeeDto GetEmployee(int id)
        {
            var employee = employeeRepository.GetById(id);
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

        public void UpdateEmployee(EmployeeDto brand)
        {
            throw new System.NotImplementedException();
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