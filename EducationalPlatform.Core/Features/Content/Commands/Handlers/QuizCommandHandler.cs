using AutoMapper;
using EducationalPlatform.Core.Bases;
using EducationalPlatform.Core.Features.Content.Commands.Models;
using EducationalPlatform.Data.Entities;
using EducationalPlatform.Service.Abstracts;
using MediatR;

namespace EducationalPlatform.Core.Features.Content.Commands.Handlers
{
    public class QuizCommandHandler : ResponseHandler,
         IRequestHandler<AddQuizCommand, Response<string>>,
         IRequestHandler<SubmitQuizCommand, Response<string>>

    {

        private readonly IMapper _mapper;
        private readonly IQuizService _quizService;

        public QuizCommandHandler(IMapper mapper, IQuizService contentService)
        {
            _quizService = contentService;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddQuizCommand request, CancellationToken cancellationToken)
        {

            var QuizMapper = _mapper.Map<Quiz>(request);
            var result = await _quizService.AddQuiz(QuizMapper, request.QuizQuestions);
            if (result == "Success")
            {
                return Created<string>("Added successfuly");
            }
            else
            {
                return BadRequest<string>(result);
            }
        }

        public Task<Response<string>> Handle(SubmitQuizCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
