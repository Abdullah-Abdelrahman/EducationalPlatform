using EducationalPlatform.Core.Features.Answer.Queries.Results;
using An = EducationalPlatform.Data.Entities;
namespace EducationalPlatform.Core.Mapping.Answer
{
    public partial class AnswerProfile
    {
        public void GetAnswerByIdMapping()
        {
            CreateMap<An.Answer, GetAnswerByIdResponse>().ForMember(destnation => destnation.AnswerId, opt => opt.MapFrom(src => src.AnswerId));
        }
    }
}
