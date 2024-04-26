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

        public async Task<bool> AddSupportedCurrency(SupportedCurrenciesGetDto currencyDto)
        {

            // logic
            try
            {
                // Retrieve currencies from the database
                var dbCurrencies = await _currencyRepository.GetAllAsync();

                // Convert currencyDto to HashSet for efficient lookup
                var incomingCurrencies = new HashSet<string>(currencyDto.Currencies);

                // Find currencies to remove
                var currenciesToRemove = dbCurrencies.Where(c => !incomingCurrencies.Contains(c.CurrencyCode)).ToList();

                // Find currencies to add
                var currenciesToAdd = currencyDto.Currencies.Where(c => !dbCurrencies.Any(dbC => dbC.CurrencyCode == c)).ToList();

                // Remove currencies
                foreach (var currency in currenciesToRemove)
                {
                    _unitOfWork.Currencies.Delete(currency);
                }

                // Add currencies
                foreach (var currency in currenciesToAdd)
                {
                    var dbCurrency = new Currency()
                    {
                        CurrencyCode = currency,
                        IsFiat = currencyDto.CurrencyType == "fiat"
                    };
                    await _unitOfWork.Currencies.CreateAsync(dbCurrency);
                }

                await _unitOfWork.SaveChangesAsync();

            }
            catch
            {
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
