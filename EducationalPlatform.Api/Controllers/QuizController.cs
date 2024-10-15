using EducationalPlatform.Api.Base;
using EducationalPlatform.Core.Features.Content.Commands.Models;
using EducationalPlatform.Data.MetaData;
using EducationalPlatform.Service.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace EducationalPlatform.Api.Controllers
{
    [ApiController]
    public class QuizController : AppControllerBase
    {

        private readonly IQuizService _quizService;

        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }



        [HttpPost(Router.QuizRouter.Create)]
        public async Task<IActionResult> CreateQuiz([FromBody] AddQuizCommand command)
        {
            var response = await Mediator.Send(command);

            return NewResult(response);
        }


    }
}
