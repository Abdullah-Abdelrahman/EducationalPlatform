using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalPlatform.Data.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

       
        public virtual ICollection<Enrollment> Enrollments { get; set; }

        public virtual ICollection<Content> Contents { get; set; }
        public virtual ICollection<CourseContent> CourseContents { get; set; }



        public Course()
        {
            Enrollments = new HashSet<Enrollment>();
            CourseContents = new HashSet<CourseContent>();
            Contents =new HashSet<Content>();
        }
    }

}
