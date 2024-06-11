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
        private readonly ICurrencyValueRepository _currencyValueRepository;
        public CurrencyService(IUnitOfWork unitOfWork, IMapper mapper, ICurrencyRepository currencyRepository, ICurrencyValueRepository currencyValueRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currencyRepository = currencyRepository;
            _currencyValueRepository = currencyValueRepository;
        }

        public async Task<bool> AddSupportedCurrency(SupportedCurrenciesGetDto currencyDto)
        {
            try
            {
                var currencyType = Enum.Parse<CurrencyType>(currencyDto.CurrencyType, ignoreCase: true);
                var dbCurrencies = await _currencyRepository.GetAllByType(currencyType);
                var incomingCurrencies = new HashSet<string>(currencyDto.Currencies);

                var currenciesToRemove = dbCurrencies.Where(c => !incomingCurrencies.Contains(c.CurrencyCode)).ToList();
                var currenciesToAdd = currencyDto.Currencies.Where(c => !dbCurrencies.Any(dbC => dbC.CurrencyCode == c)).ToList();

                foreach (var currency in currenciesToRemove)
                {
                    var currencyValuesToRemove = await _currencyValueRepository.GetByCurrencyIdToListAsync(currency.Id);
                    foreach (var currencyValue in currencyValuesToRemove)
                    {
                        _unitOfWork.CurrencyValues.Delete(currencyValue);
                    }
                    _unitOfWork.Currencies.Delete(currency);
                }

                foreach (var currency in currenciesToAdd)
                {
                    var dbCurrency = new Currency()
                    {
                        CurrencyCode = currency,
                        IsFiat = currencyType == CurrencyType.Fiat
                    };

                    await _unitOfWork.Currencies.CreateAsync(dbCurrency);


                    await _unitOfWork.SaveChangesAsync(); // Save changes here

                    // Detach the Currency from the DbContext
                    _unitOfWork.Detach(dbCurrency);

                    var dbCurrencyValue = new CurrencyValue
                    {
                        PortfolioId = 1, // Adjust as needed
                        CurrencyId = dbCurrency.Id, // Assign CurrencyId here
                        Value = 0 // Set initial value
                    };

                    await _unitOfWork.CurrencyValues.CreateAsync(dbCurrencyValue);
                    await _unitOfWork.SaveChangesAsync(); // Save changes again
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
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
