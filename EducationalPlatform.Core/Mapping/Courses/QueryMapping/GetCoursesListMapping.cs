using EducationalPlatform.Core.Features.Courses.Queries.Results;
using EducationalPlatform.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalPlatform.Core.Mapping.Courses
{
    public partial class CourseProfile
    {
     
        public void GetCoursesListMapping()
        {
            CreateMap<Course, GetCoursesResponse>().ForMember(destnation => destnation.Description, opt => opt.MapFrom(src => src.Description));
        }
    }
}
