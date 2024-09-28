using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalPlatform.Data.Entities
{
    public class Assignment : Content
    {
        public int TotalMarks { get; set; }
        public ICollection<Question> Questions { get; set; }
    }

}
