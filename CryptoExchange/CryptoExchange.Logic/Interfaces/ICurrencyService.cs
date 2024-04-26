using CryptoExchange.Domain.Dto;

namespace CryptoExchange.Logic.Interfaces
{
    public interface ICurrencyService
    {
        public Task<bool> AddSupportedCurrency(SupportedCurrenciesGetDto currencyDto);

        public Task<CurrencyPostDto[]> GetSupportedFiat();
        public Task<CurrencyPostDto[]> GetSupportedCrypto();

    }
}
