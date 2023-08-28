using CryptoExchange.Domain.Models;

namespace CryptoExchange.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        public Task<IEnumerable<TEntity>> GetAllAsync();

        public Task<TEntity> GetAsync(int id);

        public Task CreateAsync(TEntity entity);

        public void Update(TEntity entity);

        public void Delete(TEntity entity);
    }
}
