using AutoMapper;
using EducationalPlatform.Core.Bases;
using EducationalPlatform.Core.Features.Answer.Queries.Models;
using EducationalPlatform.Core.Features.Answer.Queries.Results;
using EducationalPlatform.Service.Abstracts;
using MediatR;
namespace EducationalPlatform.Core.Features.Answer.Queries.Handles
{
    public class AnswerQueryHandler : ResponseHandler, IRequestHandler<GetAnswerByIdQuery, Response<GetAnswerByIdResponse>>,
        IRequestHandler<GetAnswerListQuery, Response<List<GetAnswerListResponse>>>
    {
        #region Fields
        private readonly IAnswerService _answerService;

        private readonly IMapper _mapper;
        #endregion
        public AnswerQueryHandler(IAnswerService answerService, IMapper mapper)
        {
            _answerService = answerService;
            _mapper = mapper;
        }


        public async Task<Response<List<GetAnswerListResponse>>> Handle(GetAnswerListQuery request, CancellationToken cancellationToken)
        {
            var AnswerList = await _answerService.GetAnswersListAsync();

            var AnswerListMapper = _mapper.Map<List<GetAnswerListResponse>>(AnswerList);

            return Success(AnswerListMapper);
        }

        public async Task<Response<GetAnswerByIdResponse>> Handle(GetAnswerByIdQuery request, CancellationToken cancellationToken)
        {
            var answer = await _answerService.GetAnswerByIdAsync(request.Id);


            if (answer == null)
            {
                return NotFound<GetAnswerByIdResponse>("Answer Not Found");
            }
            else
            {
                var answerMapper = _mapper.Map<GetAnswerByIdResponse>(answer);
                return Success(answerMapper);
            }
        }

    }
}
