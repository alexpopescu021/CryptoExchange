using AutoMapper;
using CryptoExchange.Domain.Dto;
using CryptoExchange.Domain.Models;
using CryptoExchange.Logic.Interfaces;
using CryptoExchange.Repository.Interfaces;

namespace CryptoExchange.Logic.Aggregates
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordHelper _passwordHelper;
        public UserService(IMapper mapper, IPasswordHelper passwordHelper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _passwordHelper = passwordHelper;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Register(string requestUsername, byte[] passwordHash, byte[] passwordSalt)
        {
            var user = await _unitOfWork.Users.GetByUsernameAsync(requestUsername);
            if (user != null)
            {
                return false;
            }

            user = new User
            {
                Username = requestUsername,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };

            await _unitOfWork.Users.CreateAsync(user);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<UserDto> GetUser(string requestUsername)
        {
            var user = await _unitOfWork.Users.GetByUsernameAsync(requestUsername);
            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }

        public async Task<UserDto> UpdateUser(string username, UserUpdateDto userUpdateDto)
        {
            var user = await _unitOfWork.Users.GetByUsernameAsync(username);
            if (user == null)
            {
                return null;
            }

            user.FirstName = userUpdateDto.FirstName;
            user.LastName = userUpdateDto.LastName;
            user.Email = userUpdateDto.Email;
            user.TelephoneNumber = userUpdateDto.TelephoneNumber;
            user.Address = userUpdateDto.Address;

            _unitOfWork.Users.Update(user);

            return _mapper.Map<UserDto>(user);
        }

    }
}
