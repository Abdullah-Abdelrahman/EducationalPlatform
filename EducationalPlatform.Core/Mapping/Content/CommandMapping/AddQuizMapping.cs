using EducationalPlatform.Core.Features.Content.Commands.Models;
using EducationalPlatform.Data.Entities;

namespace EducationalPlatform.Core.Mapping.Content
{
    public partial class ContentProfile
    {
        public void AddQuizMapping()
        {
            CreateMap<AddQuizCommand, Quiz>().ForMember(destnation => destnation.Title, opt => opt.MapFrom(src => src.Title)).ForMember(destnation => destnation.TotalMarks, opt => opt.MapFrom(src => src.TotalMarks));

            CreateMap<AddQuizCommand, Quiz>()
           .ForMember(dest => dest.QuizQuestions, opt => opt.Ignore());
        }
    }
}
