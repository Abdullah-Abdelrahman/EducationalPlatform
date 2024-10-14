using EducationalPlatform.Core.Bases;
using MediatR;

namespace EducationalPlatform.Core.Features.Content.Commands.Models
{
    public class DeleteContentCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }

        public DeleteContentCommand(int id)
        {
            Id = id;
        }
    }
}
