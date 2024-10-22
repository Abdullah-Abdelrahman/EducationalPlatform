using EducationalPlatform.Data.Entities;
using EducationalPlatform.Infrastructure.Abstracts;
using EducationalPlatform.Infrastructure.Bases;
using EducationalPlatform.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EducationalPlatform.Infrastructure.Repositories
{
    public class QuizQuestionAnswerRepository : GenericRepository<QuizQuestionAnswer>, IQuizQuestionAnswerRepository
    {
        private readonly DbSet<QuizQuestionAnswer> _quizQuestionAnswers;

        public QuizQuestionAnswerRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _quizQuestionAnswers = dbContext.Set<QuizQuestionAnswer>();
        }
    }
}
