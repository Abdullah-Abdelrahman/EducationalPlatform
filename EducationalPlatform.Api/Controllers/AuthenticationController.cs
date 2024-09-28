using EducationalPlatform.Api.Base;
using EducationalPlatform.Core.Features.Authentication.Commands.Models;
using EducationalPlatform.Data.MetaData;
using Microsoft.AspNetCore.Mvc;

namespace EducationalPlatform.Api.Controllers
{
    [ApiController]
    public class AuthenticationController : AppControllerBase
    {



        [HttpPost(Router.AuthenticationRouter.SignIn)]
        public async Task<IActionResult> CreateToken([FromForm] SignInCommand command)
        {
            var response = await Mediator.Send(command);

            return NewResult(response);
        }

    }
}
