using EducationalPlatform.Data.Entities;
using EducationalPlatform.Infrastructure.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalPlatform.Infrastructure.Abstracts
{
    public interface ICourseRepository:IGenericRepository<Course>
    {

        public Task<List<Course>> GetCoursesListAsync();
    }
}
