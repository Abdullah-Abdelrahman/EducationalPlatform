using EducationalPlatform.Api.Base;
using EducationalPlatform.Core.Features.Enrollment.Commands.Models;
using EducationalPlatform.Data.MetaData;
using Microsoft.AspNetCore.Mvc;

namespace EducationalPlatform.Api.Controllers
{

    [ApiController]
    public class EnrollmentController : AppControllerBase
    {
        [HttpPost(Router.EnrollmentRouter.Create)]
        public async Task<IActionResult> CreateEnrollment([FromBody] AddEnrollmentCommand command)
        {
            var response = await Mediator.Send(command);

            return NewResult(response);
        }
    }
}
