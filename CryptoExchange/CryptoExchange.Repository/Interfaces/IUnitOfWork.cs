namespace CryptoExchange.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        ITransactionRepository Transactions { get; }
        IUserRepository Users { get; }

        ICurrencyRepository Currencies { get; }

        public Task<int> SaveChangesAsync();
    }
}
