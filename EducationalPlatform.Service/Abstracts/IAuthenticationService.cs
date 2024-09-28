using EducationalPlatform.Data.Entities;

namespace EducationalPlatform.Service.Abstracts
{
    public interface IAuthenticationService
    {

        public Task<string> GetJWTtoken(AppUser user);
    }
}
