using EducationalPlatform.Core.Bases;
using MediatR;

namespace EducationalPlatform.Core.Features.Answer.Commands.Models
{
    public class EditAnswerCommand : IRequest<Response<string>>
    {
        public int AnswerId { get; set; }

        public string AnswerText { get; set; }


    }
}
