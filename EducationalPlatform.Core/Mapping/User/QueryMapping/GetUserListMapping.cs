using EducationalPlatform.Core.Features.AppUser.Queries.Results;
using EducationalPlatform.Data.Entities;

namespace EducationalPlatform.Core.Mapping.User
{
    public partial class AppUserProfile
    {

        public void GetUserListMapping()
        {
            CreateMap<AppUser, GetUserListResponse>().ForMember(destnation => destnation.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(destnation => destnation.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(destnation => destnation.UserId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
