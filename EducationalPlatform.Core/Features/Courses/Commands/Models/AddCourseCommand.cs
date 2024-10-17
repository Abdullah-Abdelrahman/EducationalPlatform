using EducationalPlatform.Core.Bases;
using EducationalPlatform.Data.Dto;
using MediatR;

namespace EducationalPlatform.Core.Features.Courses.Commands.Models
{
    public class AddCourseCommand : IRequest<Response<string>>
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public List<CourseContentDto>? Content { get; set; }


    }


}
