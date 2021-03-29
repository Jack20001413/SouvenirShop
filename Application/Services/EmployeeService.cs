using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Repositories;
using SouvenirShop.Domain.Entities;

namespace Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IGrantPermissionRepository grantPermissionRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository
                                 ,IMapper mapper
                                 ,IGrantPermissionRepository grantPermissionRepository)
        {
            this.employeeRepository = employeeRepository;
            this.grantPermissionRepository = grantPermissionRepository;
            _mapper = mapper;
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
            List<GrantPermission> grantPermissions = (List<GrantPermission>)grantPermissionRepository.GetByRoleId(employeeFullDto.RoleFull.Id);
            var grantPermissionDtos = _mapper.Map<List<GrantPermissionDto>>(grantPermissions);
            employeeFullDto.RoleFull.GrantPermissions = grantPermissionDtos;
            return employeeFullDto;
        }

        public void UpdateEmployee(EmployeeDto brand)
        {
            throw new System.NotImplementedException();
        }
    }
}