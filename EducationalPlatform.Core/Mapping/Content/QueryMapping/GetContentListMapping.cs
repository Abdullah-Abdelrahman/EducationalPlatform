using EducationalPlatform.Core.Features.Content.Queries.Results;
using Entities = EducationalPlatform.Data.Entities;
namespace EducationalPlatform.Core.Mapping.Content
{
    public partial class ContentProfile
    {
        public void GetContentListMapping()
        {
            CreateMap<Entities.Content, GetContentListResponse>()
                .ForMember(destnation => destnation.ContentId, opt => opt.MapFrom(src => src.ContentId));

            CreateMap<Entities.Content, GetContentListResponse>().ForMember(destnation => destnation.Title, opt => opt.MapFrom(src => src.Title));

            CreateMap<Entities.Content, GetContentListResponse>()
               .ForMember(destnation => destnation.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<Entities.Content, GetContentListResponse>().ForMember(destnation => destnation.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt));

            CreateMap<Entities.Content, GetContentListResponse>().ForMember(destnation => destnation.ContentType, opt => opt.MapFrom(src => src.ContentType));
        }
    }
}
