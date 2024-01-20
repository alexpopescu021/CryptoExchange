using CryptoExchange.Domain.Dto;

namespace CryptoExchange.Logic.Interfaces
{
    public interface ICurrencyService
    {
        public Task<bool> AddSupportedCurrency(CurrencyGetDto[] currencyDto);

        public Task<CurrencyPostDto[]> GetSupportedFiat();
        public Task<CurrencyPostDto[]> GetSupportedCrypto();

    }
}
