using EducationalPlatform.Data.Entities;

namespace EducationalPlatform.Service.Abstracts
{
    public interface IQuizService
    {
        // public Task<string> AddQuiz(AddQuizRequest request);

        public Task<string> DeleteQuizById(int id);

        public Task<List<Quiz>> GetQuizListAsync();

        public Task<List<Quiz>> GetQuizWithAnswerListAsync();


        //public Task<GetQuizResult> GetQuizByIdAsync(int id);


        //  public Task<string> UpdateQuizAsync(EditQuizResult Quiz);
    }
}
