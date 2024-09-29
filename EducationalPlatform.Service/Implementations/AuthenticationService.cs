using EducationalPlatform.Data.Entities;
using EducationalPlatform.Service.Abstracts;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EducationalPlatform.Service.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;
        public AuthenticationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Task<string> GetJWTtoken(AppUser user)
        {
            var claims = new List<Claim>(){
                new Claim("UserName",user.UserName),
                  new Claim("Email",user.Email)
            };



            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:securityKey"]));
            var Jwttoken = new JwtSecurityToken(_configuration["JWT:Issuer"], _configuration["JWT:Audience"],
                claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials:
                new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(Jwttoken);


            return Task.FromResult(accessToken);
        }
    }
}
