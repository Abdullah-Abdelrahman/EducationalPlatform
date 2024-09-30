using EducationalPlatform.Data.Entities;
using EducationalPlatform.Infrastructure.Abstracts;
using EducationalPlatform.Service.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace EducationalPlatform.Service.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<string> AddCourse(Course course)
        {
            //Check if there is a Course with the same Name in the DB

            bool exist = _courseRepository.GetTableAsTracking().Where(c => c.Name == course.Name).Any();

            if (exist)
            {

                return "Exist";
            }
            else
            {

                await _courseRepository.AddAsync(course);
                return "Success";
            }


        }

        public async Task<string> DeleteAsync(Course course)
        {
            await _courseRepository.DeleteAsync(course);
            return "Success";
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            var course = _courseRepository.GetTableNoTracking().Where(x => x.CourseId == id).Include(x => x.Contents).SingleOrDefault();

            return course;
        }

        public async Task<List<Course>> GetCoursesListAsync()
        {
            return await _courseRepository.GetCoursesListAsync();
        }

        public async Task<string> UpdateAsync(Course course)
        {

            var transact = _courseRepository.BeginTransaction();
            try
            {
                await _courseRepository.UpdateAsync(course);

                await transact.CommitAsync();
                return "Success";

            }
            catch
            {
                await transact.RollbackAsync();
                return "Falied";
            }

        }
    }
}
