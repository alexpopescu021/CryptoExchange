using CryptoExchange.Domain.Dto;
using CryptoExchange.Domain.Models;
using CryptoExchange.Logic.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CryptoExchange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IPasswordHelper _passwordHelper;
        private readonly IConfiguration _configuration;

        public AuthController(IUserService userService, UserManager<IdentityUser> userManager, IPasswordHelper passwordHelper, IConfiguration configuration)
        {
            _userService = userService;
            _userManager = userManager;
            _passwordHelper = passwordHelper;
            _configuration = configuration;
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

            // Create JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, request.Username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Issuer"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new
            {
                Username = request.Username,
                Token = tokenString
            });
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
