using AutoMapper;
using CryptoExchange.Domain.Dto;
using CryptoExchange.Domain.Models;

namespace CryptoExchange.Logic.Aggregates
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<Transaction, TransactionGetDto>();
            //.ForMember(dest => dest.ConversionRate, opt => opt.MapFrom(src => src.ConversionRate));
            CreateMap<Transaction, TransactionPostDto>();

        }
    }
}
