using Microsoft.AspNetCore.Identity;

namespace EducationalPlatform.Service.Abstracts
{
    public interface IAuthorizationService
    {
        public Task<bool> IsRoleExistByName(string roleName);

        public Task<bool> IsRoleExistById(string roleId);

        public Task<List<IdentityRole>> GetRolesList();

        public Task<IdentityRole> GetRoleById(string id);

        public Task<string> DeleteRoleAsync(IdentityRole role);
    }
}
