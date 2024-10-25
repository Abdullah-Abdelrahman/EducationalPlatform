
using EducationalPlatform.Core.Bases;
using MediatR;

namespace EducationalPlatform.Core.Features.Authentication.Queries.Models
{
    public class ConfirmEmailQuery : IRequest<Response<string>>
    {
        public string userId { get; set; }

        public string code { get; set; }
    }
}
