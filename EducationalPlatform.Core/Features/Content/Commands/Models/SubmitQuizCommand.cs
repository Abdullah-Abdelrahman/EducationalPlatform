using EducationalPlatform.Data.Dto;
using MediatR;

namespace EducationalPlatform.Core.Features.Content.Commands.Models
{
    public class SubmitQuizCommand : IRequest<Bases.Response<string>>
    {
        public int SubmitId { get; set; }

        public int QuizId { get; set; }

        public string UserId { get; set; }

        public List<QuizQuestionAnswerDto>? quizQuestionAnswers { get; set; }
    }
}
