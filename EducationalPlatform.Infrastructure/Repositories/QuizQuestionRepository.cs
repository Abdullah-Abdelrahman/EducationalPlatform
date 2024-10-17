using EducationalPlatform.Data.Entities;
using EducationalPlatform.Infrastructure.Abstracts;
using EducationalPlatform.Infrastructure.Bases;
using EducationalPlatform.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EducationalPlatform.Infrastructure.Repositories
{
    public class QuizQuestionRepository : GenericRepository<QuizQuestion>, IQuizQuestionRepository
    {
        private readonly DbSet<QuizQuestion> _quizQuestions;
        public QuizQuestionRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _quizQuestions = dbContext.Set<QuizQuestion>();
        }
    }
}
