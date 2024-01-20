using CryptoExchange.Domain.Models;
using CryptoExchange.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CryptoExchange.Repository
{
    public class CurrencyRepository : GenericRepository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(DatabaseContext context) : base(context)
        {

        }
        public async Task<Currency?> GetByCodeAsync(string currencyCode)
        {
            return await DbContext.Currencies.Where(u => u.CurrencyCode == currencyCode).FirstOrDefaultAsync();
        }

        public async Task<List<Currency>> GetAllByType(CurrencyType type)
        {
            bool isFiat = type == CurrencyType.Fiat;

            return await DbContext.Currencies
                .Where(u => u.IsFiat == isFiat)
                .ToListAsync();
        }
    }
}
