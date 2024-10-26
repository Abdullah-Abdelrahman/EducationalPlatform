using EducationalPlatform.Core.Bases;
using MediatR;

namespace EducationalPlatform.Core.Features.AppUser.Commands.Models
{
    public class ChangeUserPasswordCommand : IRequest<Response<string>>
    {

        public string Email { get; set; }

        public string NewPassword { get; set; }

        public string NewConfirmPassword { get; set; }




    }
}
