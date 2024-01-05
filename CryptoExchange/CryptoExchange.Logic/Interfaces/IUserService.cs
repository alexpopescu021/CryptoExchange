using CryptoExchange.Domain.Dto;

namespace CryptoExchange.Logic.Interfaces
{
    public interface IUserService
    {
        Task<bool> Register(string requestUsername, byte[] passwordHash, byte[] passwordSalt);

        Task<UserDto> GetUser(string requestUsername);
    }
}
