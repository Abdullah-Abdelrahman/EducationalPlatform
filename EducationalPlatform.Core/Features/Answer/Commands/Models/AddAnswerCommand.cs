using EducationalPlatform.Core.Bases;
using MediatR;

namespace EducationalPlatform.Core.Features.Answer.Commands.Models
{
    public class AddAnswerCommand : IRequest<Response<string>>
    {
        public string AnswerText { get; set; }
    }
}
