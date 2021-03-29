using Application.DTOs;
using AutoMapper;
using SouvenirShop.Domain.Entities;

namespace Application.Profiles
{
    public class RoleFullProfile : Profile
    {
        public RoleFullProfile()
        {
            CreateMap<Role, RoleFullDto>();
            CreateMap<RoleFullDto, Role>();
        }
    }
}