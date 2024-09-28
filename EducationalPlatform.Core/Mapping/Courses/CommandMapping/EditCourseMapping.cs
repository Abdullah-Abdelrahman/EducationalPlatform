using EducationalPlatform.Core.Features.Courses.Commands.Models;
using EducationalPlatform.Data.Entities;

namespace EducationalPlatform.Core.Mapping.Courses
{
    public partial class CourseProfile
    {

        public void EditCourseMapping()
        {

            CreateMap<EditCourseCommand, Course>().ForMember(destnation => destnation.CourseId, opt => opt.MapFrom(src => src.Id));

        }
    }
}
