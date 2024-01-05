using CryptoExchange.Domain.Models;
using CryptoExchange.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CryptoExchange.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {

        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await DbContext.Users.Where(u => u.Username == username).FirstOrDefaultAsync();
        }
    }
}
