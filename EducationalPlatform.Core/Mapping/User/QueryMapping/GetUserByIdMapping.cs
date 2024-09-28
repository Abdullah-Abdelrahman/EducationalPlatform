using AutoMapper;
using EducationalPlatform.Core.Features.AppUser.Queries.Results;
using EducationalPlatform.Data.Entities;

namespace EducationalPlatform.Core.Mapping.User
{
    public partial class AppUserProfile : Profile
    {
        public void GetUserByIdMapping()
        {
            CreateMap<AppUser, GetUserByIdResponse>().ForMember(destnation => destnation.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber)).ForMember(destnation => destnation.UserName, opt => opt.MapFrom(src => src.UserName));
        }
    }
}
