using EducationalPlatform.Data.Entities;

namespace EducationalPlatform.Service.Abstracts
{
    public interface IAppUserService
    {
        public Task<string> AddUserAsync(AppUser appUser, string password);

        public Task<string> ChangePasswordAsync(string Email, string password);

    }
}
