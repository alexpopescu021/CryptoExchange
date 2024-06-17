using CryptoExchange.Domain.Dto;
using CryptoExchange.Domain.Models;
using CryptoExchange.Repository.Interfaces;

namespace CryptoExchange.Repository
{
   public class PortfolioRepository : GenericRepository<Portfolio>, IPortfolioRepository
{
    public PortfolioRepository(DatabaseContext context) : base(context)
    {
    }

    public decimal? GetCurrencyValueAsync(string currency)
    {
        var currencyValue = DbContext.CurrencyValue.Where(cv => cv.Currency.CurrencyCode == currency).FirstOrDefault();

        return currencyValue?.Value ?? 0m;
    }

    public List<CurrencyValue> GetPortfolio(int id)
    {
        return DbContext.CurrencyValue.Where(cv => cv.PortfolioId == id).ToList();
    }
}
}
