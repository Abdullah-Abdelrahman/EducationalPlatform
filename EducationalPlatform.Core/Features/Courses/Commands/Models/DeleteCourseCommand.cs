using EducationalPlatform.Core.Bases;
using MediatR;

namespace EducationalPlatform.Core.Features.Courses.Commands.Models
{
    public class DeleteCourseCommand : IRequest<Response<string>>
    {

        public int Id { get; set; }
        public DeleteCourseCommand(int id)
        {
            Id = id;
        }
    }
}
