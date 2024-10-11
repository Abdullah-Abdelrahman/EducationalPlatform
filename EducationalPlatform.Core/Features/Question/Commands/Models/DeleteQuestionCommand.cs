using EducationalPlatform.Core.Bases;
using MediatR;

namespace EducationalPlatform.Core.Features.Question.Commands.Models
{
    public class DeleteQuestionCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteQuestionCommand(int id)
        {
            Id = id;
        }
    }
}
