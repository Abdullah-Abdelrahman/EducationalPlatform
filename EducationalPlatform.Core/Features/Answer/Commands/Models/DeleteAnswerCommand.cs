using EducationalPlatform.Core.Bases;
using MediatR;

namespace EducationalPlatform.Core.Features.Answer.Commands.Models
{
    public class DeleteAnswerCommand : IRequest<Response<string>>
    {

        public int Id { get; set; }

        public DeleteAnswerCommand(int id)
        {
            Id = id;
        }
    }
}
