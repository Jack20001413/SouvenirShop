using Application.DTOs;
using AutoMapper;
using SouvenirShop.Domain.Entities;

namespace Application.Profiles
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<Supplier, SupplierDto>();
            CreateMap<SupplierDto, Supplier>();
        }
    }
}