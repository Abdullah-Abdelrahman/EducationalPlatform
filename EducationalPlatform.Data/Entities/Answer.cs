using System.Text.Json.Serialization;

namespace EducationalPlatform.Data.Entities
{
    public class Answer
    {
        public int AnswerId { get; set; }

        public string AnswerText { get; set; }

        [JsonIgnore]
        public ICollection<ChooseQuestion> ChooseQuestions { get; set; }

        [JsonIgnore]
        public ICollection<TrueOrFalseQuestion> TrueOrFalseQuestions { get; set; }


    }
}
