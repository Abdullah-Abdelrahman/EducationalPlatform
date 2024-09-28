using EducationalPlatform.Data.Entities;

namespace EducationalPlatform.Service.Abstracts
{
    public interface ICourseService
    {

        public Task<List<Course>> GetCoursesListAsync();

        public Task<Course> GetCourseByIdAsync(int id);

        public Task<string> AddCourse(Course course);

        public Task<string> UpdateAsync(Course course);

        public Task<string> DeleteAsync(Course course);

    }
}
