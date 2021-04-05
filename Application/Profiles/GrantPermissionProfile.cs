using Application.DTOs;
using AutoMapper;
using SouvenirShop.Domain.Entities;

namespace Application.Profiles
{
    public class GrantPermissionProfile : Profile
    {
        public GrantPermissionProfile()
        {
            CreateMap<GrantPermission, GrantPermissionDto>();
            CreateMap<GrantPermissionDto, GrantPermission>();
        }
    }
}