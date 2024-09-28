using EducationalPlatform.Api.Base;
using EducationalPlatform.Core.Features.AppUser.Commands.Models;
using EducationalPlatform.Core.Features.AppUser.Queries.Models;
using EducationalPlatform.Data.MetaData;
using Microsoft.AspNetCore.Mvc;

namespace EducationalPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAppController : AppControllerBase
    {


        [HttpPost(Router.UserRouter.Create)]
        public async Task<IActionResult> CreateCourse([FromBody] AddUserCommand command)
        {
            var response = await Mediator.Send(command);

            return NewResult(response);
        }


        [HttpGet(Router.UserRouter.GetList)]
        public async Task<IActionResult> GetUserList()
        {
            var response = await Mediator.Send(new GetUserListQuery());

            return Ok(response);
        }


        [HttpGet(Router.UserRouter.GetById)]
        public async Task<IActionResult> GetUserById(string Id)
        {
            var response = await Mediator.Send(new GetUserByIdQuery(Id));

            return NewResult(response);
        }

        [HttpPut(Router.UserRouter.Edit)]
        public async Task<IActionResult> EditUser([FromBody] EditUserCommand command)
        {
            var response = await Mediator.Send(command);

            return NewResult(response);
        }

        [HttpDelete(Router.UserRouter.Delete)]
        public async Task<IActionResult> DeleteCourseById([FromRoute] string Id)
        {
            var response = await Mediator.Send(new DeleteUserCommand(Id));

            return NewResult(response);
        }



        [HttpPut(Router.UserRouter.ChangePassword)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangeUserPasswordCommand command)
        {
            var response = await Mediator.Send(command);

            return NewResult(response);
        }
    }
}
