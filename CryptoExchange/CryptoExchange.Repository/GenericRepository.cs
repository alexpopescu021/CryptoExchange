using CryptoExchange.Domain.Models;
using CryptoExchange.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CryptoExchange.Repository
{
    public abstract class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly DatabaseContext DbContext;
        protected readonly DbSet<TEntity> DbSet;
        public GenericRepository(DatabaseContext context)
        {
            DbContext = context;
            DbSet = DbContext.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<TEntity> GetAsync(int id)
        {
            var result = await DbSet.FirstOrDefaultAsync(e => e.Id == id);

            //TODO Fix not found exception
            //if (result == null)
            //{
            //    throw new HttpResponseException(HttpStatusCode.NotFound);
            //}

            return await DbSet.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task CreateAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

    }
}
