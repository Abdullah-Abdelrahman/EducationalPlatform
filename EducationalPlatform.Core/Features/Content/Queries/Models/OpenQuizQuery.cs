using EducationalPlatform.Core.Bases;
using EducationalPlatform.Data.Dto;
using MediatR;

namespace EducationalPlatform.Core.Features.Content.Queries.Models
{
    public class OpenQuizQuery : IRequest<Response<OpenQuizDto>>
    {

        public int QuizId { get; set; }

        public string UserId { get; set; }


        public OpenQuizQuery(int quizId, string userId)
        {
            QuizId = quizId;
            UserId = userId;
        }
    }
}
