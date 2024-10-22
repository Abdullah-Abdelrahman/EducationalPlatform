

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationalPlatform.Data.Entities
{
    public class Submit
    {
        [Key]
        public int SubmitId { get; set; }

        public int QuizId { get; set; }

        public string UserId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? Partialresult { get; set; }

        public int? Totalresult { get; set; }

        public List<QuizQuestionAnswer>? quizQuestionAnswers { get; set; }


        [ForeignKey("QuizId")]
        public Quiz Quiz { get; set; }


        [ForeignKey("UserId")]
        public AppUser AppUser { get; set; }

    }
}
