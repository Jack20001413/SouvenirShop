using Application.DTOs;
using AutoMapper;
using SouvenirShop.Domain.Entities;

namespace Application.Profiles
{
    public class SellingTransactionProfile : Profile
    {
        public SellingTransactionProfile()
        {
            CreateMap<SellingTransaction, SellingTransactionDto>();
            CreateMap<SellingTransactionDto, SellingTransaction>();
        }
    }
}