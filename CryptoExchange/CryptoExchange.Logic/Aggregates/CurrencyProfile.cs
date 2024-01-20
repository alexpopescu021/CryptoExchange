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
        }
    }
}
