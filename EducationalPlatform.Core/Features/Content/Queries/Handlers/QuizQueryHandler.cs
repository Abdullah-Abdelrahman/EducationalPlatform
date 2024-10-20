using EducationalPlatform.Core.Bases;
using EducationalPlatform.Core.Features.Content.Queries.Models;
using EducationalPlatform.Data.Dto;
using EducationalPlatform.Service.Abstracts;
using MediatR;

namespace EducationalPlatform.Core.Features.Content.Queries.Handlers
{
    public class QuizQueryHandler : ResponseHandler,
        IRequestHandler<OpenQuizQuery, Response<OpenQuizDto>>
    {
        private readonly IQuizService _quizService;

        public QuizQueryHandler(IQuizService quizService)
        {
            _quizService = quizService;
        }


        public async Task<Response<OpenQuizDto>> Handle(OpenQuizQuery request, CancellationToken cancellationToken)
        {
            var response = await _quizService.OpenQuizSubmitAsync(request.QuizId, request.UserId);


            return Success<OpenQuizDto>(response);
        }
    }
}
