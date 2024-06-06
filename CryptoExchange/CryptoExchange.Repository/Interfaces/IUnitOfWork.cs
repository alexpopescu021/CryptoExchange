using CryptoExchange.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoExchange.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        ITransactionRepository Transactions { get; }
        IUserRepository Users { get; }
        ICurrencyRepository Currencies { get; }
        IPortfolioRepository Portfolio { get; }
        ICurrencyValueRepository CurrencyValues { get; }

        public Task<int> SaveChangesAsync();
        public void Detach(IEntity entity);
        public EntityState GetEntityState(IEntity entity);
    }
}
