using EducationalPlatform.Core.Bases;
using MediatR;

namespace EducationalPlatform.Core.Features.AppUser.Commands.Models
{
    public class DeleteUserCommand : IRequest<Response<string>>
    {
        public string UserId { get; set; }

        public DeleteUserCommand(string id)
        {
            UserId = id;
        }

    }
}
