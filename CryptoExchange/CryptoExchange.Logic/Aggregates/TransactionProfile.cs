using AutoMapper;
using CryptoExchange.Domain.Dto;
using CryptoExchange.Domain.Models;

namespace CryptoExchange.Logic.Aggregates
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<Transaction, TransactionGetDto>()
                .ForMember(d => d.TargetCurrencyCode, o => o.MapFrom(s => s.TargetCurrency.CurrencyCode))
                .ForMember(d => d.SourceCurrencyCode, o => o.MapFrom(s => s.SourceCurrency.CurrencyCode))
                .ForMember(d => d.Username, o => o.MapFrom(s => s.User.Username));
            //.ForMember(dest => dest.ConversionRate, opt => opt.MapFrom(src => src.ConversionRate));
            CreateMap<Transaction, TransactionPostDto>();

        }
    }
}
