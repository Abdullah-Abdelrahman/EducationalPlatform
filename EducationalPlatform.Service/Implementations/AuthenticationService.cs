using EducationalPlatform.Data.Entities;
using EducationalPlatform.Infrastructure.Data;
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
        private readonly IEmailService _emailService;
        private readonly ApplicationDBContext _dbContext;
        public AuthenticationService(IConfiguration configuration, UserManager<AppUser> userManager, IEmailService emailService, ApplicationDBContext applicationDBContext)
        {
            _dbContext = applicationDBContext;
            _userManager = userManager;
            _configuration = configuration;
            _emailService = emailService;
        }

        public async Task<string> ConfirmEmail(string userId, string code)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return $"No user With id ={userId}";
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);

            if (!result.Succeeded)
            {
                return "Error in confirming email : " + string.Join(",", result.Errors.Select(x => x.Description).ToList());
            }

            return "Success";
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
            var userclaims = await _userManager.GetClaimsAsync(user);
            foreach (var claim in userclaims)
            {
                claims.Add(claim);
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

        public async Task<string> SendResetPassword(string Email)
        {
            var transact = _dbContext.Database.BeginTransaction();
            try
            {
                var user = await _userManager.FindByEmailAsync(Email);

                if (user == null)
                {
                    return "UserNotFound";
                }
                var generator = new Random();

                user.Code = generator.Next(0, 1000000).ToString("D6");

                var updateResult = await _userManager.UpdateAsync(user);

                if (!updateResult.Succeeded)
                {
                    return "ErrorInUpdateUserCode";
                }
                var message = $"Code to Reset Pasword : {user.Code}";
                await _emailService.SendEmailAsync(Email, message, "Reset Pasword");
                await transact.CommitAsync();
                return "Success";
            }
            catch
            {
                await transact.RollbackAsync();
                return "Falied";
            }

        }
    }
}
