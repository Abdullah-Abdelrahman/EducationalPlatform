using EducationalPlatform.Core.Bases;
using MediatR;

namespace EducationalPlatform.Core.Features.Courses.Commands.Models
{
    public class AddCourseCommand : IRequest<Response<string>>
    {

        public string Name { get; set; }

        public string Description { get; set; }



    }
}
