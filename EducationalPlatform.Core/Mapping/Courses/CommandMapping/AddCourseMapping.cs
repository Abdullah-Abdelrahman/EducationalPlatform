using EducationalPlatform.Core.Features.Courses.Commands.Models;
using EducationalPlatform.Data.Entities;

namespace EducationalPlatform.Core.Mapping.Courses
{
    public partial class CourseProfile
    {

        public void AddCourseMapping()
        {
            CreateMap<AddCourseCommand, Course>().ForMember(destnation => destnation.Description, opt => opt.MapFrom(src => src.Description));
        }
    }
}
