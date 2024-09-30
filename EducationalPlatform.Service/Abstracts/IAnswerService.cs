using EducationalPlatform.Data.Entities;

namespace EducationalPlatform.Service.Abstracts
{
    public interface IAnswerService
    {
        public Task<List<Answer>> GetAnswersListAsync();

        public Task<Answer> GetAnswerByIdAsync(int id);

        public Task<string> AddAnswer(Answer answer);

        public Task<string> UpdateAsync(Answer answer);

        public Task<string> DeleteAsync(Answer answer);
    }
}
