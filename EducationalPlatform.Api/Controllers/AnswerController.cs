using EducationalPlatform.Api.Base;
using EducationalPlatform.Core.Features.Answer.Commands.Models;
using EducationalPlatform.Core.Features.Answer.Queries.Models;
using EducationalPlatform.Data.MetaData;
using Microsoft.AspNetCore.Mvc;

namespace EducationalPlatform.Api.Controllers
{

    [ApiController]
    public class AnswerController : AppControllerBase
    {


        [HttpPost(Router.AnswerRouter.Create)]
        public async Task<IActionResult> CreateAnswer([FromBody] AddAnswerCommand command)
        {
            var response = await Mediator.Send(command);

            return NewResult(response);
        }


        [HttpGet(Router.AnswerRouter.GetById)]
        public async Task<IActionResult> GetAnswerById(int Id)
        {
            var response = await Mediator.Send(new GetAnswerByIdQuery(Id));

            return NewResult(response);
        }


        [HttpGet(Router.AnswerRouter.GetList)]
        public async Task<IActionResult> GetAnswerList()
        {
            var response = await Mediator.Send(new GetAnswerListQuery());

            return Ok(response);
        }

        [HttpPut(Router.AnswerRouter.Edit)]
        public async Task<IActionResult> EditAnswer([FromBody] EditAnswerCommand command)
        {
            var response = await Mediator.Send(command);

            return NewResult(response);
        }


        [HttpDelete(Router.AnswerRouter.Delete)]
        public async Task<IActionResult> DeleteAnswerById([FromRoute] int Id)
        {
            var response = await Mediator.Send(new DeleteAnswerCommand(Id));

            return NewResult(response);
        }

    }
}
