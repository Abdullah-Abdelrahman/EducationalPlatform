using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalPlatform.Data.Entities
{
    public abstract class Content
    {
        public int ContentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }


        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<CourseContent> CourseContents { get; set; }
    }

}
