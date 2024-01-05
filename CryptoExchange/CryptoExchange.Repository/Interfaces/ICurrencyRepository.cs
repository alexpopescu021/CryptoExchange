using CryptoExchange.Domain.Models;

namespace CryptoExchange.Repository.Interfaces
{
    public interface ICurrencyRepository : IGenericRepository<Currency>
    {
        object GetByCurrency(string currencySymbol);
    }
}
