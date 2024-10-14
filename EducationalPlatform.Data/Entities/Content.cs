namespace EducationalPlatform.Data.Entities
{
    public abstract class Content
    {
        public int ContentId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public string ContentType { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<CourseContent> CourseContents { get; set; }
    }

}
