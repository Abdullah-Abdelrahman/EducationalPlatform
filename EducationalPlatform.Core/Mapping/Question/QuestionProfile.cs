using AutoMapper;

namespace EducationalPlatform.Core.Mapping.Question
{
    public partial class QuestionProfile : Profile
    {

        public QuestionProfile()
        {
            GetQuestionListMapping();
            AddChooseQuestionWithAnswerMapping();

        }
    }
}
