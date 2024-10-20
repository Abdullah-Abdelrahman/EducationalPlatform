using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EducationalPlatform.Data.Entities
{
    public abstract class Question
    {
        public int QuestionId { get; set; }

        public string QuestionText { get; set; }

        public string? QuestionImage { get; set; }

        public int CorrectAnswerId { get; set; }

        public string QuestionType { get; set; }

        [JsonIgnore]
        public virtual ICollection<QuizQuestion> QuizQuestions { get; set; }

        [JsonIgnore]
        public ICollection<Quiz> Quizs { get; set; }

        [JsonIgnore]
        public ICollection<Assignment> Assignments { get; set; }


        [JsonIgnore]
        [ForeignKey("CorrectAnswerId")]
        public Answer Answer { get; set; }
    }


}
