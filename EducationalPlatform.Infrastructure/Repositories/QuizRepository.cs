using EducationalPlatform.Data.Entities;
using EducationalPlatform.Infrastructure.Abstracts;
using EducationalPlatform.Infrastructure.Bases;
using EducationalPlatform.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EducationalPlatform.Infrastructure.Repositories
{
    public class QuizRepository : GenericRepository<Quiz>, IQuizRepository
    {
        private readonly DbSet<Quiz> _quizzes;

        public QuizRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _quizzes = dbContext.Set<Quiz>();

        }


    }
}
