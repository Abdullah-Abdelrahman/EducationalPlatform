using EducationalPlatform.Data.Entities;
using EducationalPlatform.Infrastructure.Abstracts;
using EducationalPlatform.Infrastructure.Bases;
using EducationalPlatform.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EducationalPlatform.Infrastructure.Repositories
{
    public class EnrollmentRepository : GenericRepository<Enrollment>, IEnrollmentRepository
    {
        private readonly DbSet<Enrollment> _enrollments;

        public EnrollmentRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _enrollments = dbContext.Set<Enrollment>();
        }
    }
}
