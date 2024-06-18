using CryptoExchange.Domain.Dto;
using CryptoExchange.Domain.Models;
using CryptoExchange.Logic.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CryptoExchange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IPasswordHelper _passwordHelper;

        public AuthController(IUserService userService, UserManager<IdentityUser> userManager, IPasswordHelper passwordHelper)
        {
            _userService = userService;
            _userManager = userManager;
            _passwordHelper = passwordHelper;
        }

        [HttpGet]
        public ActionResult<string> GetMe()
        {
            var userName = _userManager.GetUserAsync(HttpContext.User);
            return Ok(userName);
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            _passwordHelper.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            if (await _userService.Register(request.Username, passwordHash, passwordSalt))
            {
                return Ok(request);
            }
            return BadRequest("User already exists");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDto request)
        {
            var user = await _userService.GetUser(request.Username);
            if (user == null)
            {
                return BadRequest("User not found.");
            }

            if (!await _passwordHelper.VerifyPasswordHash(request.Password, request))
            {
                return BadRequest("Wrong password.");
            }

            return Ok(request);
        }

        [HttpPut("{username}")]
        public async Task<IActionResult> UpdateUser(string username, UserUpdateDto userUpdateDto)
        {
            var userDto = await _userService.UpdateUser(username, userUpdateDto);

            if (userDto == null)
            {
                return NotFound();
            }

            return Ok(userDto);
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<UserUpdateDto>> GetUser(string username)
        {
            var userDto = await _userService.GetUser(username);

            if (userDto == null)
            {
                return NotFound();
            }

            return Ok(userDto);
        }

        [HttpPost("conversionRate")]
        public async Task<IActionResult> ChangeConversionRate([FromBody] decimal amount)
        {
            //var user = await _userService.GetUser(request.Username);
            //if (user == null)
            //{
            //    return BadRequest("User not found.");
            //}

            //if (!await _passwordHelper.VerifyPasswordHash(request.Password, request))
            //{
            //    return BadRequest("Wrong password.");
            //}

            //return Ok();
            return null;
        }

    }
}
