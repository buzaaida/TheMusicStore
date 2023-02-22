using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using TheMusicStoreServices.Interfaces;
using TheMusicStoreServices.Models;
using TheMusicStoreServices.Services.TheMusicStoreServices.Services;

namespace TheMusicStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        

        public AuthController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        [HttpGet]
        [Route("getUserByRole"), Authorize]
        public async Task<ActionResult<string>> GetUserByRole()
        {
            return User.FindFirstValue(ClaimTypes.Role);
        }




        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(User request)
        {
            //var user = await _userService.GetUserByEmail(request.Email);
            CreatePasswordHash(request.Password, request);

            var res = await _userService.CreateUser(request);

            return Ok(res);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> login(SignIn request)
        {
            var user = await _userService.GetUserByEmail(request.Email);
            if (user.Email != request.Email)
            {
                return BadRequest("User doesn't exist.");
            }

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Incorrect password.");
            }

            string token = CreateToken(user);

            //var refreshToken = GenerateRefreshToken();
            //SetRefreshToken(refreshToken);

            return Ok(new AuthResponse { IsAuthSuccessful = true, Token = token });
        }

        //[HttpPost("refresh-token")]
        //public async Task<ActionResult<string>> RefreshToken()
        //{
        //    var refreshToken = Request.Cookies["refreshToken"];
        //    var user = 

        //    if (!user.RefreshToken.Equals(refreshToken))
        //    {
        //        return Unauthorized("Invalid Refresh Token.");
        //    }
        //    else if (user.TokenExpires < DateTime.Now)
        //    {
        //        return Unauthorized("Token expired.");
        //    }

        //    string token = CreateToken(user);
        //    var newRefreshToken = GenerateRefreshToken();
        //    SetRefreshToken(newRefreshToken);

        //    return Ok(token);
        //}

        //private RefreshToken GenerateRefreshToken()
        //{
        //    var refreshToken = new RefreshToken
        //    {
        //        Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
        //        Expires = DateTime.Now.AddDays(7),
        //        Created = DateTime.Now
        //    };

        //    return refreshToken;
        //}
        //private void SetRefreshToken(RefreshToken newRefreshToken)
        //{
        //    var cookieOptions = new CookieOptions
        //    {
        //        HttpOnly = true,
        //        Expires = newRefreshToken.Expires
        //    };
        //    Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);

        //    user.RefreshToken = newRefreshToken.Token;
        //    user.TokenCreated = newRefreshToken.Created;
        //    user.TokenExpires = newRefreshToken.Expires;
        //}
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, " ")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
        private void CreatePasswordHash(string password, User user)
        {
            using (var hmac = new HMACSHA512())
            {
                user.PasswordSalt = hmac.Key;
                user.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

    }
}
