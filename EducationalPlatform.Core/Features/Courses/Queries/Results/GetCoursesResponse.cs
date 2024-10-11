namespace EducationalPlatform.Core.Features.Courses.Queries.Results
{
    public class GetCoursesResponse
    {

        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string CorrectAnswer { get; set; }

    }
}
