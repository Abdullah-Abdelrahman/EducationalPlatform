using EducationalPlatform.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace EducationalPlatform.Service.Abstracts
{
    public interface ICourseService
    {

        public Task<List<Course>> GetCoursesListAsync();

        public Task<Course> GetCourseByIdAsync(int id);

        public Task<string> AddCourse(Course course, List<int> contentDto, IFormFile? ImageFile, string? webRootPath);

        public Task<string> UpdateAsync(Course course);

        public Task<string> DeleteAsync(Course course);

    }
}
