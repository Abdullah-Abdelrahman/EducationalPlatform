using EducationalPlatform.Core.Features.Answer.Commands.Models;
using An = EducationalPlatform.Data.Entities;
namespace EducationalPlatform.Core.Mapping.Answer
{
    public partial class AnswerProfile
    {

        public void AddAnswerMapping()
        {
            CreateMap<AddAnswerCommand, An.Answer>().ForMember(destnation => destnation.AnswerText, opt => opt.MapFrom(src => src.AnswerText));
        }
    }
}
