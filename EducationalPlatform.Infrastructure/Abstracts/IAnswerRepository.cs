using EducationalPlatform.Data.Entities;
using EducationalPlatform.Infrastructure.Bases;

namespace EducationalPlatform.Infrastructure.Abstracts
{
    public interface IAnswerRepository : IGenericRepository<Answer>
    {
        public Task<List<Answer>> GetAnswersListAsync();
    }
}
