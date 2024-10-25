using EducationalPlatform.Data.Entities;
using EducationalPlatform.Infrastructure.Data;
using EducationalPlatform.Service.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace EducationalPlatform.Service.Implementations
{
    public class AppUserService : IAppUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailService _emailService;

        private readonly ApplicationDBContext _dbContext;
        //Used to get the host and schema(http or https)
        private readonly IHttpContextAccessor _contextAccessor;


        public AppUserService(UserManager<AppUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            IEmailService emailService,
            ApplicationDBContext applicationDBContext)
        {
            _contextAccessor = httpContextAccessor;
            _dbContext = applicationDBContext;
            _userManager = userManager;
            _emailService = emailService;
        }
        public async Task<string> AddUserAsync(AppUser appUser, string password)
        {
            var transact = _dbContext.Database.BeginTransaction();
            try
            {
                //if email Exist before

                var Emailresult = await _userManager.FindByEmailAsync(appUser.Email);

                if (Emailresult == null)
                {
                    var UserNameresult = await _userManager.FindByNameAsync(appUser.UserName);

                    if (UserNameresult == null)
                    {

                        var result = await _userManager.CreateAsync(appUser, password);

                        if (result == IdentityResult.Success)
                        {
                            var addRoleResult = await _userManager.AddToRoleAsync(appUser, "User");

                            if (addRoleResult == IdentityResult.Success)
                            {
                                //send Confirm Email
                                var code = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);

                                var requestAccessor = _contextAccessor.HttpContext.Request;
                                var returnUrl = requestAccessor.Scheme + "://" + requestAccessor.Host + $"/Api/Authentication/ConfirmEmail?userId={appUser.Id}&code={code}";
                                //send the confirmation email

                                var message = $"To confirm Your Email Click the link <a href='{returnUrl}'></a>";
                                await _emailService.SendEmailAsync(appUser.Email, message, "Confirm Email");


                                await transact.CommitAsync();
                                return "Success";

                            }
                            else
                            {
                                return "UserCreatedSuccessfullyButNotAddedTo[user]Role";
                            }
                        }
                        else
                        {
                            return string.Join(",", result.Errors.Select(x => x.Description).ToList());
                        }

                    }
                    else
                    {
                        return "UserNameAlredyExist";
                    }
                }
                else
                {
                    return "EmailAlredyExist";
                }



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
