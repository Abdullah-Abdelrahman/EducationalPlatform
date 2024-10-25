using EducationalPlatform.Core.Bases;
using MediatR;

namespace EducationalPlatform.Core.Features.Authentication.Commands.Models
{
    public class ResetPasswordCommand : IRequest<Response<string>>
    {

        public string Email { get; set; }
    }
}
