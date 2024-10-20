namespace EducationalPlatform.Data.Dto
{
    public class OpenQuizDto
    {
        public int SubmitId { get; set; }

        public int QuizId { get; set; }

        public string UserId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public List<QuizSubmitQuestionDto>? Questions { get; set; }
    }

}
