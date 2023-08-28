namespace CryptoExchange.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        ITransactionRepository Transactions { get; }

        public Task<int> SaveChangesAsync();
    }
}
