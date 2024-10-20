using EducationalPlatform.Data.Dto;
using EducationalPlatform.Data.Entities;
using EducationalPlatform.Infrastructure.Abstracts;
using EducationalPlatform.Service.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace EducationalPlatform.Service.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        private readonly ICourseContentRepository _courseContentRepository;

        private readonly IContentService _contentService;
        public CourseService(ICourseRepository courseRepository, ICourseContentRepository courseContentRepository, IContentService contentService)
        {
            _courseContentRepository = courseContentRepository;
            _courseRepository = courseRepository;
            _contentService = contentService;
        }

        public async Task<string> AddCourse(Course course, List<CourseContentDto> contentDto)
        {
            //Check if there is a Course with the same Name in the DB

            bool exist = _courseRepository.GetTableAsTracking().Where(c => c.Name == course.Name).Any();

            if (exist)
            {

                return "Exist";
            }
            else
            {

                var newCourse = await _courseRepository.AddAsync(course);

                if (newCourse != null)
                {
                    foreach (var content in contentDto)
                    {
                        if ((await _contentService.ExistByIdAsync(content.ContentId)))
                        {
                            await _courseContentRepository.AddAsync(new CourseContent()
                            {
                                CourseId = newCourse.CourseId,
                                ContentId = content.ContentId,

                            });
                        }

                    }
                }


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
