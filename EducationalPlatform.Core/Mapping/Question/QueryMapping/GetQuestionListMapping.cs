using EducationalPlatform.Core.Features.Question.Queris.Results;
using Q = EducationalPlatform.Data.Entities;
namespace EducationalPlatform.Core.Mapping.Question
{
    public partial class QuestionProfile
    {
        public void GetQuestionListMapping()
        {
            CreateMap<Q.Question, GetQuestionListResponse>().ForMember(destnation => destnation.QuestionText, opt => opt.MapFrom(src => src.QuestionText));

            CreateMap<Q.Question, GetQuestionListResponse>().ForMember(destnation => destnation.QuestionId, opt => opt.MapFrom(src => src.QuestionId));

            CreateMap<Q.Question, GetQuestionListResponse>().ForMember(destnation => destnation.QuestionType, opt => opt.MapFrom(src => src.QuestionType));

            CreateMap<Q.Question, GetQuestionListResponse>().ForMember(destnation => destnation.CorrectAnswer, opt => opt.MapFrom(src => src.Answer.AnswerText));
        }

    }
}
