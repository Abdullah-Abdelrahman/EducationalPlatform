namespace EducationalPlatform.Data.Dto
{
    public class EditQuestionResult
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }

        public string? QuestionImage { get; set; }

        public string QuestionType { get; set; }


        //for chose and true or false questions or Writen
        public int? correctAnswerId { get; set; }
        //

        //for choose qustions
        public ICollection<int>? answerListIds { get; set; }
        //
    }
}
