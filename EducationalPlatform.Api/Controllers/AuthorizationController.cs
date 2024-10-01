using EducationalPlatform.Api.Base;
using EducationalPlatform.Core.Features.Authorization.Commands.Models;
using EducationalPlatform.Core.Features.Authorization.Quaries.Models;
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


        [HttpGet(Router.AuthorizationRouter.GetList)]
        public async Task<IActionResult> GetRoleList()
        {
            var response = await Mediator.Send(new GetRoleListQuery());

            return Ok(response);
        }

        [HttpGet(Router.AuthorizationRouter.GetById)]
        public async Task<IActionResult> GetRoleById(string Id)
        {
            var response = await Mediator.Send(new GetRoleByIdQuery(Id));

            return NewResult(response);
        }

        [HttpPut(Router.AuthorizationRouter.Edit)]
        public async Task<IActionResult> EditAnswer([FromForm] EditRoleCommand command)
        {
            var response = await Mediator.Send(command);

            return NewResult(response);
        }


        [HttpDelete(Router.AuthorizationRouter.Delete)]
        public async Task<IActionResult> DeleteRoleById([FromRoute] string Id)
        {
            var response = await Mediator.Send(new DeleteRoleCommand(Id));

            return NewResult(response);
        }



    }
}
