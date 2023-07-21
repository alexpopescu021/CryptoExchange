using CryptoExchange.Domain.Models;

namespace CryptoExchange.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public Task<List<Entity>> GetAllAsync();

        public Task<Entity> GetAsync(int id);

        public Task CreateAsync(Entity entity);

        public void Update(Entity entity);

        public void Delete(Entity entity);

        public Task SaveChangesAsync();
    }
}
