using AutoMapper;

namespace EducationalPlatform.Core.Mapping.Authorization
{
    public partial class RoleProfile : Profile
    {
        public RoleProfile()
        {
            GetRoleListMapping();


            GetRoleByIdMapping();
        }
    }
}
