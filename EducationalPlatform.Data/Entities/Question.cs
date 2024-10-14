using System.ComponentModel.DataAnnotations.Schema;

namespace EducationalPlatform.Data.Entities
{
    public abstract class Question
    {
        public int QuestionId { get; set; }

        public string QuestionText { get; set; }

        public string? QuestionImage { get; set; }

        public int CorrectAnswerId { get; set; }

        public string QuestionType { get; set; }


        public virtual ICollection<QuizQuestion> QuizQuestions { get; set; }

        public ICollection<Quiz> Quizs { get; set; }

        public ICollection<Assignment> Assignments { get; set; }


        [ForeignKey("CorrectAnswerId")]
        public Answer Answer { get; set; }
    }


}
