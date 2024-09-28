using AutoMapper;

namespace EducationalPlatform.Core.Mapping.Courses
{
    public partial class CourseProfile : Profile
    {

        public CourseProfile()
        {
            GetCoursesListMapping();
            GetCourseByIdMapping();
            AddCourseMapping();
            EditCourseMapping();
        }
    }
}
