using CryptoExchange.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CryptoExchange.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
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

        public IQueryable<TEntity> GetQuery()
        {
            return DbSet.AsQueryable();
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return (await DbContext.Set<TEntity>().FindAsync(id))!;

            //TODO Fix not found exception
            //if (result == null)
            //{
            //    throw new HttpResponseException(HttpStatusCode.NotFound);
            //}

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
