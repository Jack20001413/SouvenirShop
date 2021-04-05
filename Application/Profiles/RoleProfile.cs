using Application.DTOs;
using AutoMapper;
using SouvenirShop.Domain.Entities;

namespace Application.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleFullDto>();
            CreateMap<RoleFullDto, Role>();
        }
    }
}