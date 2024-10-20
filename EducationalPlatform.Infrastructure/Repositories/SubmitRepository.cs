using EducationalPlatform.Data.Entities;
using EducationalPlatform.Infrastructure.Abstracts;
using EducationalPlatform.Infrastructure.Bases;
using EducationalPlatform.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EducationalPlatform.Infrastructure.Repositories
{
    public class SubmitRepository : GenericRepository<Submit>, ISubmitRepository
    {
        private readonly DbSet<Submit> _submits;

        public SubmitRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _submits = dbContext.Set<Submit>();


        }
    }
}
