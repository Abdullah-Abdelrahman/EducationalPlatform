using EducationalPlatform.Data.Dto;
using EducationalPlatform.Data.Entities;
using EducationalPlatform.Infrastructure.Abstracts;
using EducationalPlatform.Service.Abstracts;

namespace EducationalPlatform.Service.Implementations
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _quizRepository;

        private readonly IQuizQuestionRepository _quizQuestionRepository;
        public QuizService(IQuizRepository quizRepository, IQuizQuestionRepository quizQuestionRepository)
        {
            _quizQuestionRepository = quizQuestionRepository;
            _quizRepository = quizRepository;
        }
        public async Task<string> AddQuiz(Quiz quiz, List<QuizQuestionDto>? quizQuestions)
        {

            quiz.ContentType = "Quiz";

            var newQuiz = await _quizRepository.AddAsync(quiz);



            foreach (var question in quizQuestions)
            {
                await _quizQuestionRepository.AddAsync(new QuizQuestion()
                {
                    QuizId = newQuiz.ContentId,
                    QuestionId = question.QuestionId,
                    Points = question.Points,

                });
            }



            return "Success";
        }

        public Task<string> DeleteQuizById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Quiz> GetQuizByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Quiz>> GetQuizListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateQuizAsync(Quiz Quiz)
        {
            throw new NotImplementedException();
        }
    }
}
