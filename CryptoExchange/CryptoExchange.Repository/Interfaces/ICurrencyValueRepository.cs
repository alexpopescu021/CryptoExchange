using CryptoExchange.Domain.Models;

namespace CryptoExchange.Repository.Interfaces
{
    public interface ICurrencyValueRepository : IGenericRepository<CurrencyValue>
    {
        CurrencyValue? GetByCurrencyCodeAndPortfolioIdAsync(string currencyCode, int portfolioId);
        Task<IEnumerable<CurrencyValue>> GetByCurrencyIdToListAsync(int currencyId);
        decimal? GetCurrencyValueAsync(string currency);
        Task<CurrencyValue?> GetByCurrencyIdFirstAsync(int currencyId);

    }
}
