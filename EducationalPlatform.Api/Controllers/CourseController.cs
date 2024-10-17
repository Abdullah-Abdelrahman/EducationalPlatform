using EducationalPlatform.Api.Base;
using EducationalPlatform.Core.Features.Courses.Commands.Models;
using EducationalPlatform.Core.Features.Courses.Queries.Models;
using EducationalPlatform.Data.MetaData;
using Microsoft.AspNetCore.Mvc;

namespace EducationalPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : AppControllerBase
    {

        [HttpGet(Router.CourseRouter.GetList)]
        public async Task<IActionResult> GetCoursesList()
        {
            var response = await Mediator.Send(new GetCoursesQuery());

            return Ok(response);
        }


        [HttpGet(Router.CourseRouter.GetById)]
        public async Task<IActionResult> GetCourseById(int Id)
        {
            var response = await Mediator.Send(new GetCourseByIdQuery(Id));

            return NewResult(response);
        }


        [HttpPost(Router.CourseRouter.Create)]
        //[Authorize(Policy = "CreateCourse")]
        public async Task<IActionResult> CreateCourse([FromBody] AddCourseCommand command)
        {
            var response = await Mediator.Send(command);

            return NewResult(response);
        }





        [HttpPut(Router.CourseRouter.Edit)]
        public async Task<IActionResult> EditCourse([FromBody] EditCourseCommand command)
        {
            var response = await Mediator.Send(command);

            return NewResult(response);
        }


        [HttpDelete(Router.CourseRouter.Delete)]
        public async Task<IActionResult> DeleteCourseById([FromRoute] int Id)
        {
            var response = await Mediator.Send(new DeleteCourseCommand(Id));

            return NewResult(response);
        }
    }
}
