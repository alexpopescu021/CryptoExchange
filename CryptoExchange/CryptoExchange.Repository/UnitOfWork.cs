using CryptoExchange.Repository.Interfaces;

namespace CryptoExchange.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        public ITransactionRepository Transactions { get; }
        public IUserRepository Users { get; }
        public UnitOfWork(DatabaseContext dbContext,
            ITransactionRepository transactionRepository, IUserRepository users)
        {
            _context = dbContext;
            Transactions = transactionRepository;
            Users = users;
        }
        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
