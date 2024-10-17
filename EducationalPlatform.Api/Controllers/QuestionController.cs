using EducationalPlatform.Api.Base;
using EducationalPlatform.Core.Features.Question.Commands.Models;
using EducationalPlatform.Core.Features.Question.Queris.Models;
using EducationalPlatform.Data.MetaData;
using EducationalPlatform.Service.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace EducationalPlatform.Api.Controllers
{

    [ApiController]
    public class QuestionController : AppControllerBase
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost(Router.QuestionRouter.Create)]
        public async Task<IActionResult> CreateQuestion([FromBody] AddQuestionCommand command)
        {
            var response = await Mediator.Send(command);

            return NewResult(response);
        }


        [HttpPost(Router.QuestionRouter.CreateQuestionWithAnswer)]
        public async Task<IActionResult> CreateQuestionWithAnswer([FromBody] AddQuestionWithAnswerCommand command)
        {
            var response = await Mediator.Send(command);

            return NewResult(response);
        }


        [HttpGet(Router.QuestionRouter.GetList)]
        public async Task<IActionResult> GetQuestionList()
        {
            var response = await Mediator.Send(new GetQuestionListQuery());

            return Ok(response);
        }

        [HttpGet(Router.QuestionRouter.TypeList)]
        public async Task<IActionResult> GetQuestionTypeList()
        {
            var response = await Mediator.Send(new GetQuestionTypeListQuery());

            return Ok(response);
        }


        [HttpGet(Router.QuestionRouter.GetById)]
        public async Task<IActionResult> GetQuestionById(int Id)
        {
            var response = await Mediator.Send(new GetQuestionByIdQuery(Id));

            return NewResult(response);
        }

        [HttpPut(Router.QuestionRouter.Edit)]
        public async Task<IActionResult> EditQuestion([FromBody] EditQuestionCommand command)
        {
            var response = await Mediator.Send(command);

            return NewResult(response);
        }


        [HttpDelete(Router.QuestionRouter.Delete)]
        public async Task<IActionResult> DeleteQuestionById([FromRoute] int Id)
        {
            var response = await Mediator.Send(new DeleteQuestionCommand(Id));

            return NewResult(response);
        }

    }
}
