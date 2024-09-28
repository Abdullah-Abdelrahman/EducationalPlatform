using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalPlatform.Data.Entities
{
    public class Quiz : Content
    {
        public int TotalMarks { get; private set; }

        public ICollection<Question> QuizQuestions { get; set; }

        public Quiz() {
            QuizQuestions = new HashSet<Question>();


        }
    }

}
