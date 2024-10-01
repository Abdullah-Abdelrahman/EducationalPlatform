using EducationalPlatform.Data.Entities;
using EducationalPlatform.Service.Abstracts;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<AppUser> _userManager;
        public AuthenticationService(IConfiguration configuration, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _configuration = configuration;
        }
        public async Task<string> GetJWTtoken(AppUser user)
        {
            var claims = new List<Claim>(){
                new Claim(ClaimTypes.Name,user.UserName),
                  new Claim(ClaimTypes.Email,user.Email)
            };
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }


            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:securityKey"]));
            var Jwttoken = new JwtSecurityToken(_configuration["JWT:Issuer"], _configuration["JWT:Audience"],
                claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials:
                new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(Jwttoken);


            return await Task.FromResult(accessToken);
        }
    }
}
