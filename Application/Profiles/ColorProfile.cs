using AutoMapper;
using SouvenirShop.Domain.Entities;
using Application.DTOs;

namespace Application.Profiles
{
    public class ColorProfile : Profile
    {
        public ColorProfile()
        {
            CreateMap<Color, ColorDto>();
            CreateMap<ColorDto, Color>();
        }
    }
}