using CryptoExchange.Repository.Interfaces;

namespace CryptoExchange.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        public ITransactionRepository Transactions { get; }
        public UnitOfWork(DatabaseContext dbContext,
            ITransactionRepository transactionRepository)
        {
            _context = dbContext;
            Transactions = transactionRepository;
        }
        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
