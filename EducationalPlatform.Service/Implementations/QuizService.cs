using EducationalPlatform.Data.Entities;
using EducationalPlatform.Service.Abstracts;

namespace EducationalPlatform.Service.Implementations
{
    public class QuizService : IQuizService
    {
        public Task<string> AddQuiz(Quiz quiz)
        {
            throw new NotImplementedException();
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
