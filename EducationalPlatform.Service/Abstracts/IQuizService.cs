using EducationalPlatform.Data.Entities;

namespace EducationalPlatform.Service.Abstracts
{
    public interface IQuizService
    {
        public Task<string> AddQuiz(Quiz quiz);

        public Task<string> DeleteQuizById(int id);

        public Task<List<Quiz>> GetQuizListAsync();

        public Task<Quiz> GetQuizByIdAsync(int id);


        public Task<string> UpdateQuizAsync(Quiz Quiz);
    }
}
