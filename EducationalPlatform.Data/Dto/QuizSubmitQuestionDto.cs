using EducationalPlatform.Data.Entities;

namespace EducationalPlatform.Data.Dto
{
    public class QuizSubmitQuestionDto
    {
        public int QuestionId { get; set; }

        public string QuestionText { get; set; }

        public string? QuestionImage { get; set; }

        public ICollection<Answer> ChoiceList { get; set; }

    }
}
