using AutoMapper;

namespace EducationalPlatform.Core.Mapping.Content
{
    public partial class ContentProfile : Profile
    {
        public ContentProfile()
        {
            GetContentListMapping();
            AddQuizMapping();
        }
    }
}
