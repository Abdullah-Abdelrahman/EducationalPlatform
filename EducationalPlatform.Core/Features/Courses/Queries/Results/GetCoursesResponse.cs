using Microsoft.AspNetCore.Http;

namespace EducationalPlatform.Core.Features.Courses.Queries.Results
{
    public class GetCoursesResponse
    {

        public int CourseId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        //Image
        public IFormFile? ImageFile { get; set; }

    }
}
