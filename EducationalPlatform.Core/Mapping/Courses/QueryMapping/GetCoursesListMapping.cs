using EducationalPlatform.Core.Features.Courses.Queries.Results;
using EducationalPlatform.Data.Entities;

namespace EducationalPlatform.Core.Mapping.Courses
{
    public partial class CourseProfile
    {

        public void GetCoursesListMapping()
        {
            CreateMap<Course, GetCoursesResponse>().ForMember(destnation => destnation.Description, opt => opt.MapFrom(src => src.Description)).ForMember(destnation => destnation.ImageFile, opt => opt.MapFrom(src => src.ImageFile));
        }
    }
}
