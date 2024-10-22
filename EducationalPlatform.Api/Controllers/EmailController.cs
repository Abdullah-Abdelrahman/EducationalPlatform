using EducationalPlatform.Api.Base;
using EducationalPlatform.Core.Features.Email.Commands.Models;
using EducationalPlatform.Data.MetaData;
using Microsoft.AspNetCore.Mvc;

namespace EducationalPlatform.Api.Controllers
{

    [ApiController]
    public class EmailController : AppControllerBase
    {

        [HttpPost(Router.EmailRouter.Send)]
        public async Task<IActionResult> SendEmail([FromQuery] SendEmailCommand command)
        {
            var response = await Mediator.Send(command);

            return NewResult(response);
        }

    }
}
