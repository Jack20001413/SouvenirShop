using Application.DTOs;
using AutoMapper;
using SouvenirShop.Domain.Entities;

namespace Application.Profiles
{
    public class ProductDetailProfile : Profile
    {
        public ProductDetailProfile()
        {
            CreateMap<ProductDetail, ProductDetailDto>();
            CreateMap<ProductDetailDto, ProductDetail>();
        }
    }
}