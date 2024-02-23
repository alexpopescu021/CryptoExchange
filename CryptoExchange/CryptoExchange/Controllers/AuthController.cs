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
                return Ok();
            }
            return BadRequest();
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

            return Ok();
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
