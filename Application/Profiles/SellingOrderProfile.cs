using Application.DTOs;
using AutoMapper;
using SouvenirShop.Domain.Entities;

namespace Application.Profiles
{
    public class SellingOrderProfile : Profile
    {
        public SellingOrderProfile()
        {
            CreateMap<SellingOrder, SellingOrderDto>();
            CreateMap<SellingOrderDto, SellingOrder>();
        }
    }
}