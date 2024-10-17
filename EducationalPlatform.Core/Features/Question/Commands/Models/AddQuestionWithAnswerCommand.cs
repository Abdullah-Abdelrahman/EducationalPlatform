using EducationalPlatform.Core.Bases;
using MediatR;

namespace EducationalPlatform.Core.Features.Question.Commands.Models
{
    public class AddQuestionWithAnswerCommand : IRequest<Response<string>>
    {

        public string QuestionText { get; set; }

        public string? QuestionImage { get; set; }

        public string QuestionType { get; set; }

        public string CorrectAnswer { get; set; }

        public List<string> ChoiceList { get; set; }

    }
}
