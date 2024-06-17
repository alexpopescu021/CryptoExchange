using AutoMapper;
using CryptoExchange.Domain.Dto;
using CryptoExchange.Domain.Models;

namespace CryptoExchange.Logic.Aggregates
{
    public class CurrencyProfile : Profile
    {
        public CurrencyProfile()
        {
            CreateMap<Currency, CurrencyGetDto>();
            CreateMap<CurrencyGetDto, Currency>();

            CreateMap<Currency, CurrencyPostDto>();
            CreateMap<CurrencyPostDto, Currency>();

            CreateMap<CurrencyValue, CurrencyGetDto>()
            .ForMember(dest => dest.CurrencyCode, opt => opt.MapFrom(src => src.Currency.CurrencyCode));
        }
    }
}
