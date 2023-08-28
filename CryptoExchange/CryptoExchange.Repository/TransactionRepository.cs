using CryptoExchange.Domain.Models;
using CryptoExchange.Repository.Interfaces;

namespace CryptoExchange.Repository
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
