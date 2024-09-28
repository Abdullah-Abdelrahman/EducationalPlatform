using AutoMapper;

namespace EducationalPlatform.Core.Mapping.User
{
    public partial class AppUserProfile : Profile
    {

        public AppUserProfile()
        {
            AddUserMapping();
            EditUserMapping();

            GetUserListMapping();
            GetUserByIdMapping();
        }
    }
}
