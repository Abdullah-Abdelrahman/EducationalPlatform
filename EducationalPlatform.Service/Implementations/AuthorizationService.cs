using EducationalPlatform.Data.Entities;
using EducationalPlatform.Service.Abstracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EducationalPlatform.Service.Implementations
{
    internal class AuthorizationService : IAuthorizationService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public AuthorizationService(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<string> DeleteRoleAsync(IdentityRole role)
        {

            var result = await _roleManager.DeleteAsync(role);


            //check if any user has this rule
            var users = _userManager.GetUsersInRoleAsync(role.Name);

            if (result.Succeeded)
            {
                return "Success";
            }
            else
            {
                return "Failed";
            }
        }

        public async Task<IdentityRole> GetRoleById(string id)
        {
            return await _roleManager.FindByIdAsync(id);
        }

        public Task<List<IdentityRole>> GetRolesList()
        {
            var roles = _roleManager.Roles;

            return roles.ToListAsync();
        }

        public async Task<bool> IsRoleExistById(string roleId)
        {
            var result = await _roleManager.FindByIdAsync(roleId);
            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
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
