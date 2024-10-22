using AutoMapper;

namespace EducationalPlatform.Core.Mapping.Enrollment
{
    public partial class EnrollmentProfile : Profile
    {
        public EnrollmentProfile()
        {
            AddEnrollmentMapping();
        }

    }
}
