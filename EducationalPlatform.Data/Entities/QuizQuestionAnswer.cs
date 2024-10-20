using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationalPlatform.Data.Entities
{
    public class QuizQuestionAnswer
    {
        [Key]
        public int SubmitId { get; set; }

        public int QuestionId { get; set; }

        public int AnswerId { get; set; }

        [ForeignKey("QuestionId")]
        public Question Question { get; set; }

        [ForeignKey("AnswerId")]
        public Answer Answer { get; set; }

        [ForeignKey("SubmitId")]
        public Submit Sumbit { get; set; }

    }
}
