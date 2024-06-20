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

            CreateMap<Transaction, TransactionPostDto>()
                .ForMember(dest => dest.TargetCurrencyCode, opt => opt.MapFrom(s => s.TargetCurrency.CurrencyCode))
                .ForMember(dest => dest.SourceCurrencyCode, opt => opt.MapFrom(s => s.SourceCurrency.CurrencyCode));

            CreateMap<TransactionPostDto, Transaction>()
                .ForMember(dest => dest.SourceCurrencyId, opt => opt.Ignore())
                .ForMember(dest => dest.TargetCurrencyId, opt => opt.Ignore())
                .ForMember(dest => dest.TransactionDate, opt => opt.MapFrom(src => src.TransactionDate))
                .ForMember(dest => dest.SourcePrice, opt => opt.MapFrom(src => src.SourcePrice))
                .ForMember(dest => dest.TargetPrice, opt => opt.MapFrom(src => src.TargetPrice))
                .ForMember(dest => dest.ConversionRate, opt => opt.Ignore());

            CreateMap<ExternalTransactionDto, Transaction>()
                .ForMember(dest => dest.SourceCurrencyId, opt => opt.MapFrom(src => src.CurrencyId))
                .ForMember(dest => dest.SourcePrice, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.TargetPrice, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.ConversionRate, opt => opt.MapFrom(src => 1)) // Assuming a direct conversion
                .ForMember(dest => dest.TargetCurrencyId, opt => opt.Ignore());

            CreateMap<Transaction, ExternalTransactionDto>()
                .ForMember(dest => dest.Iban, opt => opt.Ignore())
                .ForMember(dest => dest.Card, opt => opt.Ignore());

            // New mapping for Transaction to TransactionDto
            CreateMap<Transaction, TransactionDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.SourceCurrencyId, opt => opt.MapFrom(src => src.SourceCurrencyId))
                .ForMember(dest => dest.TargetCurrencyId, opt => opt.MapFrom(src => src.TargetCurrencyId))
                .ForMember(dest => dest.TransactionDate, opt => opt.MapFrom(src => src.TransactionDate))
                .ForMember(dest => dest.SourcePrice, opt => opt.MapFrom(src => src.SourcePrice))
                .ForMember(dest => dest.TargetPrice, opt => opt.MapFrom(src => src.TargetPrice))
                .ForMember(dest => dest.ConversionRate, opt => opt.MapFrom(src => src.ConversionRate));
        }
    }
}
