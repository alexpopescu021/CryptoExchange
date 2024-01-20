using CryptoExchange.Domain.Models;

namespace CryptoExchange.Repository.Interfaces
{
    public interface ICurrencyRepository : IGenericRepository<Currency>
    {
        public Task<Currency?> GetByCodeAsync(string currencyCode);
        public Task<List<Currency>> GetAllByType(CurrencyType type);
    }
}
