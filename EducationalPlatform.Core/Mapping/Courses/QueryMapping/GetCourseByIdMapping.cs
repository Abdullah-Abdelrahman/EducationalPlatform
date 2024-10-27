using EducationalPlatform.Core.Features.Courses.Queries.Results;
using EducationalPlatform.Data.Entities;

namespace EducationalPlatform.Core.Mapping.Courses
{
    public partial class CourseProfile
    {

        public void GetCourseByIdMapping()
        {
            CreateMap<Course, GetCourseByIdResponse>().ForMember(destnation => destnation.Description, opt => opt.MapFrom(src => src.Description)).ForMember(destnation => destnation.ContentsId, opt => opt.MapFrom(src => src.CourseContents.Select(c => c.ContentId))).ForMember(destnation => destnation.ImageFile, opt => opt.MapFrom(src => src.ImageFile));
        }
    }
}
