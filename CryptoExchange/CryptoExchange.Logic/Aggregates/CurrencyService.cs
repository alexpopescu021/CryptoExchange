using AutoMapper;
using CryptoExchange.Domain.Dto;
using CryptoExchange.Domain.Models;
using CryptoExchange.Logic.Interfaces;
using CryptoExchange.Repository.Interfaces;

namespace CryptoExchange.Logic.Aggregates
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrencyRepository _currencyRepository;
        public CurrencyService(IUnitOfWork unitOfWork, IMapper mapper, ICurrencyRepository currencyRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currencyRepository = currencyRepository;
        }

        public async Task<bool> AddSupportedCurrency(CurrencyGetDto[] currencyDto)
        {
            var currencyList = _mapper.Map<Currency[]>(currencyDto);

            // logic
            try { 
                foreach(var currency in currencyList)
                {
                    if(_currencyRepository.GetByCodeAsync(currency.CurrencyCode) != null)
                    {
                        await _unitOfWork.Currencies.CreateAsync(currency);
                        await _unitOfWork.SaveChangesAsync();
                    }
                }
            }
            catch { 
                return false; 
            }
            return true;
        }

        public async Task<CurrencyPostDto[]> GetSupportedFiat()
        {
            var fiats = await _currencyRepository.GetAllByType(CurrencyType.Fiat);

            return _mapper.Map<CurrencyPostDto[]>(fiats);
        }

        public async Task<CurrencyPostDto[]> GetSupportedCrypto()
        {
            var fiats = await _currencyRepository.GetAllByType(CurrencyType.Crypto);

            return _mapper.Map<CurrencyPostDto[]>(fiats);
        }
    }
}
