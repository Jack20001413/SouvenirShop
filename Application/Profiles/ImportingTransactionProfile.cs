using Application.DTOs;
using AutoMapper;
using SouvenirShop.Domain.Entities;

namespace Application.Profiles
{
    public class ImportingTransactionProfile : Profile
    {
        public ImportingTransactionProfile()
        {
            CreateMap<ImportingTransaction, ImportingTransactionDto>();
            CreateMap<ImportingTransactionDto, ImportingTransaction>();
        }
    }
}