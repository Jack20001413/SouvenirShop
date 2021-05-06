using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SouvenirShop.Application.DTOs;
using SouvenirShop.Domain.Entities;

namespace Application.DTOs
{
    public class JwtResponseDto
    {   
        public UserDto User {get; set; }
        public string Type {get; set; }
        public string Token { get; set; }

        public JwtResponseDto(EmployeeFullDto employeeFull, string token)
        {
            User = new UserDto();
            User.Id = employeeFull.Id;
            User.Name = employeeFull.Name;
            User.Username = employeeFull.Email;
            User.Permissions = new List<string>();
            foreach (GrantPermissionDto g in employeeFull.Role.GrantPermissions) {
                User.Permissions.Add(g.Permission.Code);
            }
            Token = token;
            Type = "Bearer";
        }

        public JwtResponseDto(CustomerDto customer, string token)
        {
            User = new UserDto();
            User.Id = customer.Id;
            User.Name = customer.Name;
            User.Username = customer.Email;
            User.Permissions = new List<string>();
            Token = token;
            Type = "Bearer";
        }
    }
}