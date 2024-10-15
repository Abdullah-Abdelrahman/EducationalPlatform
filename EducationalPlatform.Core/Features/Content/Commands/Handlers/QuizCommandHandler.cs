using AutoMapper;
using EducationalPlatform.Core.Bases;
using EducationalPlatform.Core.Features.Content.Commands.Models;
using EducationalPlatform.Service.Abstracts;
using MediatR;

namespace EducationalPlatform.Core.Features.Content.Commands.Handlers
{
    public class QuizCommandHandler : ResponseHandler,
         IRequestHandler<AddQuizCommand, Response<string>>
    {

        private readonly IMapper _mapper;
        private readonly IQuizService _quizService;

        public QuizCommandHandler(IMapper mapper, IQuizService contentService)
        {
            _quizService = contentService;
            _mapper = mapper;
        }

        public Task<Response<string>> Handle(AddQuizCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
