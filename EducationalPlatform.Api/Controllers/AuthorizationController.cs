using EducationalPlatform.Api.Base;
using EducationalPlatform.Core.Features.Authorization.Commands.Models;
using EducationalPlatform.Data.MetaData;
using Microsoft.AspNetCore.Mvc;

namespace EducationalPlatform.Api.Controllers
{

    [ApiController]
    public class AuthorizationController : AppControllerBase
    {


        [HttpPost(Router.AuthorizationRouter.Create)]
        public async Task<IActionResult> CreateRole([FromForm] AddRoleCommand command)
        {
            var response = await Mediator.Send(command);

            return NewResult(response);
        }
    }
}
