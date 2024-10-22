using EducationalPlatform.Core.Features.Enrollment.Commands.Models;
using En = EducationalPlatform.Data.Entities;
namespace EducationalPlatform.Core.Mapping.Enrollment
{
    public partial class EnrollmentProfile
    {
        public void AddEnrollmentMapping()
        {
            CreateMap<AddEnrollmentCommand, En.Enrollment>().ForMember(destnation => destnation.Coupon, opt => opt.MapFrom(src => src.Coupon)).
                ForMember(destnation => destnation.UserId, opt => opt.MapFrom(src => src.UserId)).
                ForMember(destnation => destnation.CourseId, opt => opt.MapFrom(src => src.CourseId));
        }
    }
}
