using EducationalPlatform.Core.Bases;
using MediatR;

namespace EducationalPlatform.Core.Features.Courses.Commands.Models
{
    public class EditCourseCommand : IRequest<Response<string>>
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
