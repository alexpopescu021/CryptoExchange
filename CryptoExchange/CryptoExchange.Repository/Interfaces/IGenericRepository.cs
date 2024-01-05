namespace CryptoExchange.Repository.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        public Task<IEnumerable<TEntity>> GetAllAsync();
        public IQueryable<TEntity> GetQuery();

        public Task<TEntity> GetAsync(int id);

        public Task CreateAsync(TEntity entity);

        public void Update(TEntity entity);

        public void Delete(TEntity entity);
    }
}
