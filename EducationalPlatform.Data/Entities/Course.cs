using System.ComponentModel.DataAnnotations.Schema;

namespace EducationalPlatform.Data.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string? ImagePath { get; set; }

        public decimal Price { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }

        public virtual ICollection<Content> Contents { get; set; }
        public virtual ICollection<CourseContent> CourseContents { get; set; }

        [NotMapped]
        public byte[] ImageFile { get; set; }
        public Course()
        {
            Enrollments = new HashSet<Enrollment>();
            CourseContents = new HashSet<CourseContent>();
            Contents = new HashSet<Content>();
        }
    }

}
