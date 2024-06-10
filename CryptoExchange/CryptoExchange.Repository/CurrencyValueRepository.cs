using CryptoExchange.Domain.Models;
using CryptoExchange.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CryptoExchange.Repository
{
    public class CurrencyValueRepository : GenericRepository<CurrencyValue>, ICurrencyValueRepository
    {
        public CurrencyValueRepository(DatabaseContext context) : base(context)
        {

        }
        public CurrencyValue? GetByCurrencyCodeAndPortfolioIdAsync(string currencyCode, int portfolioId)
        {
            return DbContext.CurrencyValue
                .Where(cv => cv.Currency.CurrencyCode == currencyCode && cv.PortfolioId == portfolioId).FirstOrDefault();
        }

        public async Task<IEnumerable<CurrencyValue>> GetByCurrencyIdAsync(int currencyId)
        {
            return await DbContext.CurrencyValue
                .Where(cv => cv.CurrencyId == currencyId)
                .ToListAsync();
        }

        public decimal? GetCurrencyValueAsync(string currency)
        {
            var currencyValue = DbContext.CurrencyValue.Where(cv => cv.Currency.CurrencyCode == currency).FirstOrDefault();

            return currencyValue?.Value ?? 0m;
        }

    }
}
