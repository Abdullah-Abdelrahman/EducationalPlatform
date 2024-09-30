using EducationalPlatform.Data.Entities;
using EducationalPlatform.Infrastructure.Abstracts;
using EducationalPlatform.Infrastructure.Bases;
using EducationalPlatform.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EducationalPlatform.Infrastructure.Repositories
{
    public class AnswerRepository : GenericRepository<Answer>, IAnswerRepository
    {

        private readonly DbSet<Answer> _answer;
        public AnswerRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _answer = dbContext.Set<Answer>();
        }

        public async Task<List<Answer>> GetAnswersListAsync()
        {
            return await _answer.ToListAsync();
        }
    }
}
