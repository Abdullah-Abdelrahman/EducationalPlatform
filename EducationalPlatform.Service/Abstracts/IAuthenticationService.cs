using EducationalPlatform.Data.Entities;

namespace EducationalPlatform.Service.Abstracts
{
    public interface IAuthenticationService
    {

        public Task<string> GetJWTtoken(AppUser user);

        public Task<string> ConfirmEmail(string userId, string code);

        public Task<string> SendResetPassword(string Email);

        public Task<string> ResetPassword(string Email, string code);


    }
}
