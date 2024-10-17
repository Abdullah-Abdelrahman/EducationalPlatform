using EducationalPlatform.Data.Entities;
using EducationalPlatform.Infrastructure.Abstracts;
using EducationalPlatform.Infrastructure.Bases;
using EducationalPlatform.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EducationalPlatform.Infrastructure.Repositories
{
    public class CourseContentRepository : GenericRepository<CourseContent>, ICourseContentRepository
    {
        private readonly DbSet<CourseContent> _courseContents;
        public CourseContentRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _courseContents = dbContext.Set<CourseContent>();
        }
    }
}
