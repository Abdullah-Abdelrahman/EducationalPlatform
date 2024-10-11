using AutoMapper;
using EducationalPlatform.Core.Bases;
using EducationalPlatform.Core.Features.Question.Commands.Models;
using EducationalPlatform.Service.Abstracts;
using MediatR;

namespace EducationalPlatform.Core.Features.Question.Commands.Handlers
{
    public class QuestionCommandHandler : ResponseHandler,
        IRequestHandler<AddQuestionCommand, Response<string>>,
        IRequestHandler<DeleteQuestionCommand, Response<string>>,
         IRequestHandler<EditQuestionCommand, Response<string>>
    {

        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;


        public QuestionCommandHandler(IQuestionService questionService
            , IMapper mapper)
        {
            _mapper = mapper;
            _questionService = questionService;
        }


        public async Task<Response<string>> Handle(AddQuestionCommand request, CancellationToken cancellationToken)
        {

            var result = await _questionService.AddQuestion(request);

            if (result == "Exist")
            {
                return UnprocessableEntity<string>("Question with the same text Exist Befor");
            }
            else if (result == "Success")
            {
                return Created<string>("Added successfuly");
            }
            else
            {
                return BadRequest<string>(result);
            }

        }

        public async Task<Response<string>> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            var result = await _questionService.DeleteQuestionById(request.Id);

            if (result == "Success")
            {
                return Success<string>(result);
            }
            else if (result == "NotFound")
            {
                return NotFound<string>($"No Question with id = {request.Id}");
            }
            else
            {
                return BadRequest<string>(result);
            }
        }


        public async Task<Response<string>> Handle(EditQuestionCommand request, CancellationToken cancellationToken)
        {

            var result = await _questionService.UpdateQuestionAsync(request);

            if (result == "Success")
            {
                return Success<string>(result);
            }
            else
            {
                return BadRequest<string>(result);
            }

        }
    }
}
