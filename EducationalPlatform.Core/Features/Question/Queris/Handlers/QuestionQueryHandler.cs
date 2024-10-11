using AutoMapper;
using EducationalPlatform.Core.Bases;
using EducationalPlatform.Core.Features.Question.Queris.Models;
using EducationalPlatform.Core.Features.Question.Queris.Results;
using EducationalPlatform.Data.Dto;
using EducationalPlatform.Service.Abstracts;
using MediatR;

namespace EducationalPlatform.Core.Features.Question.Queris.Handlers
{
    public class QuestionQueryHandler : ResponseHandler,
        IRequestHandler<GetQuestionListQuery, Response<List<GetQuestionListResponse>>>,
        IRequestHandler<GetQuestionByIdQuery, Response<GetQuestionResult>>,
         IRequestHandler<GetQuestionTypeListQuery, Response<List<string>>>

    {

        #region Fields
        private readonly IQuestionService _questionService;

        private readonly IMapper _mapper;
        #endregion

        public QuestionQueryHandler(IMapper mapper, IQuestionService questionService)
        {
            _questionService = questionService;
            _mapper = mapper;
        }

        public async Task<Response<List<GetQuestionListResponse>>> Handle(GetQuestionListQuery request, CancellationToken cancellationToken)
        {
            var questionList = await _questionService.GetQuestionWithAnswerListAsync();


            var questionMapp = _mapper.Map<List<GetQuestionListResponse>>(source: questionList);


            return Success<List<GetQuestionListResponse>>(questionMapp);

        }

        public async Task<Response<List<string>>> Handle(GetQuestionTypeListQuery request, CancellationToken cancellationToken)
        {
            List<string> TypeList = new List<string>();

            TypeList.Add("Writen");
            TypeList.Add("TrueOrFalse");
            TypeList.Add("Choose");

            return Success<List<string>>(TypeList);
        }


        async Task<Response<GetQuestionResult>> IRequestHandler<GetQuestionByIdQuery, Response<GetQuestionResult>>.Handle(GetQuestionByIdQuery request, CancellationToken cancellationToken)
        {
            var question = await _questionService.GetQuestionByIdAsync(request.Id);

            return Success<GetQuestionResult>(question);
        }
    }
}
