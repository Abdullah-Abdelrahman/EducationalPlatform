using AutoMapper;

namespace EducationalPlatform.Core.Mapping.Answer
{
    public partial class AnswerProfile : Profile
    {
        public AnswerProfile()
        {
            //Command
            AddAnswerMapping();
            EditAnswerMapping();


            //Query
            GetAnswerByIdMapping();
            GetAnswerListMapping();
        }
    }
}
