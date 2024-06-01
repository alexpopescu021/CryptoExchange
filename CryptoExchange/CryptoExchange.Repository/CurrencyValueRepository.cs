using CryptoExchange.Domain.Models;
using CryptoExchange.Repository.Interfaces;

namespace CryptoExchange.Repository
{
    public class CurrencyValueRepository : GenericRepository<CurrencyValue>, ICurrencyValueRepository
    {
        public CurrencyValueRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
