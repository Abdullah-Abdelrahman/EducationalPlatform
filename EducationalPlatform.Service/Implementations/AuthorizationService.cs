using EducationalPlatform.Service.Abstracts;
using Microsoft.AspNetCore.Identity;

namespace EducationalPlatform.Service.Implementations
{
    internal class AuthorizationService : IAuthorizationService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public AuthorizationService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public Task<IdentityRole> GetRoleById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<IdentityRole>> GetRolesList()
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsRoleExistById(int roleId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsRoleExistByName(string roleName)
        {
            var result = await _roleManager.FindByNameAsync(roleName);
            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
