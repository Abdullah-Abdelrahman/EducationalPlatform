using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalPlatform.Data.Entities
{
    public abstract class Question
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }

        public string QuestionImage { get; set; }

        public int points { get; set; }
        

        public ICollection<Quiz> Quizs { get; set; }

        public ICollection<Assignment> Assignments { get; set; }
    }

   
}
