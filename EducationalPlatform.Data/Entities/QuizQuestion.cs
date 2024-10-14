using System.ComponentModel.DataAnnotations.Schema;

namespace EducationalPlatform.Data.Entities
{
    public class QuizQuestion
    {
        public int QuizId { get; set; }

        public int QuestionId { get; set; }

        public int Points { get; set; }

        [ForeignKey("QuizId")]
        public Quiz Quiz { get; set; }

        [ForeignKey("QuestionId")]
        public Question Question { get; set; }
    }
}
