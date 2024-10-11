using EducationalPlatform.Data.Dto;
using EducationalPlatform.Data.Entities;
using EducationalPlatform.Infrastructure.Bases;

namespace EducationalPlatform.Infrastructure.Abstracts
{
    public interface IQuestionRepository : IGenericRepository<Question>
    {

        public Task<string> AddWritenQuestionAsync(WriteQuestion question);

        public Task<string> AddTrueOrFalseQuestionAsync(TrueOrFalseQuestion question);

        public Task<List<Answer>> GetChoiceListAsyncFor(string Questiontype, int id);

        public Task<string> UpdateByTypeAsync(EditQuestionResult request);

    }
}
