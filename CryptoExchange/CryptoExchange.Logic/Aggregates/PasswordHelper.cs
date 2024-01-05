using System.Security.Cryptography;
using CryptoExchange.Domain.Dto;
using CryptoExchange.Logic.Interfaces;
using CryptoExchange.Repository.Interfaces;

namespace CryptoExchange.Logic.Aggregates;
public class PasswordHelper : IPasswordHelper
{
    private readonly IUnitOfWork _unitOfWork;
    public PasswordHelper(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512();
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
    }

    public async Task<bool> VerifyPasswordHash(string password, UserDto userDto)
    {
        var userFromDb = await _unitOfWork.Users.GetByUsernameAsync(userDto.Username);
        using var hmac = new HMACSHA512(userFromDb.PasswordSalt);
        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        return computedHash.SequenceEqual(userFromDb.PasswordHash);
    }
}
