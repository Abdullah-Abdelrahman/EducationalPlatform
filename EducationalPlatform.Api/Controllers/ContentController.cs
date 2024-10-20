using EducationalPlatform.Api.Base;
using EducationalPlatform.Core.Features.Content.Commands.Models;
using EducationalPlatform.Core.Features.Content.Queries.Models;
using EducationalPlatform.Data.MetaData;
using EducationalPlatform.Service.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace EducationalPlatform.Api.Controllers
{

    [ApiController]
    public class ContentController : AppControllerBase
    {

        private readonly IQuestionService _questionService;

        public ContentController(IQuestionService questionService, IWebHostEnvironment webHostEnvironment)
        {
            _questionService = questionService;
            _webHost = webHostEnvironment;

        }

        [HttpPost(Router.ContentRouter.CreateGeneralContent)]
        public async Task<IActionResult> CreateGeneralContentCommand([FromForm] AddGeneralContentCommand command)
        {
            command.webRootPath = _webHost.ContentRootPath;
            var response = await Mediator.Send(command);
            return NewResult(response);
        }





        //All the content !!
        [HttpGet(Router.ContentRouter.GetList)]
        public async Task<IActionResult> GetContentList()
        {
            var response = await Mediator.Send(new GetContentListQuery());

            return Ok(response);
        }

        [HttpGet(Router.ContentRouter.TypeList)]
        public async Task<IActionResult> GetContentTypeList()
        {
            var response = await Mediator.Send(new GetContentTypeListQuery());

            return Ok(response);
        }


        [HttpGet(Router.ContentRouter.GetGeneralContentById)]
        public async Task<IActionResult> GetQuestionById(int Id)
        {
            var response = await Mediator.Send(new GetGeneralContentByIdQuery(Id));

            return NewResult(response);
        }

        [HttpPut(Router.ContentRouter.EditGeneralContent)]
        public async Task<IActionResult> EditQuestion([FromBody] EditGeneralContentCommand command)
        {
            var response = await Mediator.Send(command);

            return NewResult(response);
        }


        [HttpDelete(Router.ContentRouter.Delete)]
        public async Task<IActionResult> DeleteContentById([FromRoute] int Id)
        {
            var response = await Mediator.Send(new DeleteContentCommand(Id));

            return NewResult(response);
        }
    }
}
