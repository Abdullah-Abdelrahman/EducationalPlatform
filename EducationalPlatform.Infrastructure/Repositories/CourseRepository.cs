using EducationalPlatform.Data.Entities;
using EducationalPlatform.Infrastructure.Abstracts;
using EducationalPlatform.Infrastructure.Bases;
using EducationalPlatform.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalPlatform.Infrastructure.Repositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private readonly DbSet<Course> _course;
        public CourseRepository(ApplicationDBContext context):base(context) 
        {
            _course = context.Set<Course>();
        }
        public async Task<List<Course>> GetCoursesListAsync()
        {
            return await _course.ToListAsync();
        }
    }
}
