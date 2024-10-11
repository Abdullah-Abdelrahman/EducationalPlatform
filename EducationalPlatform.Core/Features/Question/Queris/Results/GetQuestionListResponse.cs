namespace EducationalPlatform.Core.Features.Question.Queris.Results
{
    public class GetQuestionListResponse
    {
        public int QuestionId { get; set; }

        public string QuestionText { get; set; }

        public string QuestionType { get; set; }

        public string CorrectAnswer { get; set; }

    }
}
