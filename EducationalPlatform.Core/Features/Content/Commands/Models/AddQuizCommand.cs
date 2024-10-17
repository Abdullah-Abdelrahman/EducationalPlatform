using EducationalPlatform.Core.Bases;
using EducationalPlatform.Data.Dto;
using MediatR;

namespace EducationalPlatform.Core.Features.Content.Commands.Models
{
    public class AddQuizCommand : IRequest<Response<string>>
    {

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }


        public int TotalMarks { get; set; }


        public List<QuizQuestionDto>? QuizQuestions { get; set; }

    }


}
