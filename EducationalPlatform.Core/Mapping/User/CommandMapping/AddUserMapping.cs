using EducationalPlatform.Core.Features.AppUser.Commands.Models;
using EducationalPlatform.Data.Entities;

namespace EducationalPlatform.Core.Mapping.User
{
    public partial class AppUserProfile
    {

        public void AddUserMapping()
        {
            CreateMap<AddUserCommand, AppUser>().ForMember(destnation => destnation.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber)).ForMember(destnation => destnation.UserName, opt => opt.MapFrom(src => src.UserName));
        }
    }
}
