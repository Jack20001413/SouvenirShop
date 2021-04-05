using Application.DTOs;
using AutoMapper;
using SouvenirShop.Domain.Entities;

namespace Application.Profiles
{
    public class PermissionProfile : Profile
    {
        public PermissionProfile()
        {
            CreateMap<Permission, PermissionDto>();
            CreateMap<PermissionDto, Permission>();
        }
    }
}