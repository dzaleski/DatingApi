using DatingApi.Dtos;
using DatingApi.Interfaces;
using DatingApi.Models;
using DatingApi.Repositories;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DatingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly ITokenService _tokenService;

        public AccountController(IUserRepository repo, ITokenService tokenService)
        {
            _repo = repo;
            _tokenService = tokenService;
        }

        //POST api/account/register
        [HttpPost("register")]
        public ActionResult<AppUserDto> Register(RegisterDto registerDto)
        {
            if (_repo.UserExists(registerDto.Username)) return BadRequest("Username is taken!");

            using var hmac = new HMACSHA512();

            var user = new AppUser() {
                Username = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            _repo.Create(user);
            _repo.SaveChanges();

            return new AppUserDto() { Username = user.Username, Token = _tokenService.CreateToken(user) };
        }

        //GET api/account/login
        [HttpPost("login")]
        public ActionResult<AppUserDto> Login(LoginDto loginDto)
        {
            var user = _repo.GetUserByUsername(loginDto.Username);

            if (user == null) return Unauthorized("Username is invalid");

            var passwordHash = ComputePassword(loginDto.Password, user.PasswordSalt);

            if (!Enumerable.SequenceEqual(passwordHash, user.PasswordHash)) return Unauthorized("Password is invalid");

            return new AppUserDto() { Username = user.Username, Token = _tokenService.CreateToken(user) };
        }
        private byte[] ComputePassword(string password, byte[] salt)
        {
            using var hmac = new HMACSHA512(salt);

            byte[] passHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return passHash;
        }

    }
}
