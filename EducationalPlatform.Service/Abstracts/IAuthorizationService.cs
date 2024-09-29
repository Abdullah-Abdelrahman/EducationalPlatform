using Microsoft.AspNetCore.Identity;

namespace EducationalPlatform.Service.Abstracts
{
    public interface IAuthorizationService
    {
        public Task<bool> IsRoleExistByName(string roleName);

        public Task<bool> IsRoleExistById(int roleId);

        public Task<List<IdentityRole>> GetRolesList();

        public Task<IdentityRole> GetRoleById(int id);
    }
}
