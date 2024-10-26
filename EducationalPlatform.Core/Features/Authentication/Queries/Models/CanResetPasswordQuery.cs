using EducationalPlatform.Core.Bases;
using MediatR;

namespace EducationalPlatform.Core.Features.Authentication.Queries.Models
{
    public class CanResetPasswordQuery : IRequest<Response<string>>
    {
        public string code { get; set; }

        public string Email { get; set; }

    }
}
