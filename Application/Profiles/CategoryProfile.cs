using Application.DTOs;
using AutoMapper;
using SouvenirShop.Domain.Entities.Common;

namespace Application.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryFullDto>();
            CreateMap<CategoryFullDto, Category>();
        }
    }
}