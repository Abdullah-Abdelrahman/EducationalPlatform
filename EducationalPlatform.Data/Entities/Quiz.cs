namespace EducationalPlatform.Data.Entities
{
    public class Quiz : Content
    {
        public int TotalMarks { get; private set; }


        public virtual ICollection<QuizQuestion> QuizQuestions { get; set; }

        public ICollection<Question> Questions { get; set; }

        public Quiz()
        {
            Questions = new HashSet<Question>();

            QuizQuestions = new HashSet<QuizQuestion>();
        }
    }

}
