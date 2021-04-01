using Application.DTOs;
using AutoMapper;
using SouvenirShop.Domain.Entities;

namespace Application.Profiles
{
    public class ImportingOrderProfile : Profile
    {
        public ImportingOrderProfile()
        {
            CreateMap<ImportingOrderDto, ImportingOrder>();
            CreateMap<ImportingOrder, ImportingOrderDto>();
        }
    }
}