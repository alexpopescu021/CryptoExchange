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
            CreateMap<Transaction, TransactionPostDto>()
                .ForMember(dest => dest.TargetCurrencyCode, opt => opt.MapFrom(s => s.TargetCurrency)) // Ignore mapping of TargetCurrency
                .ForMember(dest => dest.TargetCurrencyCode, opt => opt.MapFrom(s => s.SourceCurrency)); // Ignore mapping of SourceCurrency

            CreateMap<TransactionPostDto, Transaction>()
           .ForMember(dest => dest.SourceCurrencyId, opt => opt.Ignore()) // Ignore mapping of SourceCurrencyId
           .ForMember(dest => dest.TargetCurrencyId, opt => opt.Ignore()) // Ignore mapping of TargetCurrencyId
           .ForMember(dest => dest.TransactionDate, opt => opt.MapFrom(src => src.TransactionDate)) // Map TransactionDate directly
           .ForMember(dest => dest.SourcePrice, opt => opt.MapFrom(src => src.SourcePrice)) // Map SourcePrice directly
           .ForMember(dest => dest.TargetPrice, opt => opt.MapFrom(src => src.TargetPrice)) // Map TargetPrice directly
           .ForMember(dest => dest.ConversionRate, opt => opt.Ignore()); // Calculate ConversionRate

            CreateMap<ExternalTransactionDto, Transaction>()
                .ForMember(dest => dest.SourceCurrencyId, opt => opt.MapFrom(src => src.CurrencyId))
                .ForMember(dest => dest.SourcePrice, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.TargetPrice, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.ConversionRate, opt => opt.MapFrom(src => 1)) // Assuming a direct conversion
                .ForMember(dest => dest.TargetCurrencyId, opt => opt.Ignore()); // Target currency will be set in service
        }
    }
}
