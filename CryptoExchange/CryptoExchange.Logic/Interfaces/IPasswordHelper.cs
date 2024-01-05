using CryptoExchange.Domain.Dto;

namespace CryptoExchange.Logic.Interfaces;
public interface IPasswordHelper
{
    void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
    Task<bool> VerifyPasswordHash(string password, UserDto userDto);
}
