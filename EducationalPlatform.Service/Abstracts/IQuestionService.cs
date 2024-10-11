using EducationalPlatform.Data.Dto;
using EducationalPlatform.Data.Entities;

namespace EducationalPlatform.Service.Abstracts
{
    public interface IQuestionService
    {

        public Task<string> AddQuestion(AddQuestionRequest request);

        public Task<string> DeleteQuestionById(int id);

        public Task<List<Question>> GetQuestionListAsync();

        public Task<List<Question>> GetQuestionWithAnswerListAsync();


        public Task<GetQuestionResult> GetQuestionByIdAsync(int id);


        public Task<string> UpdateQuestionAsync(EditQuestionResult question);

    }
}
