using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalPlatform.Data.Entities
{
    public class Answer
    {
        public int AnswerId { get; set; }

        public string AnswerText {  get; set; }


        public ICollection<ChooseQuestion> ChooseQuestions { get; set; }
       
        public ICollection<TrueOrFalseQuestion> TrueOrFalseQuestions { get; set; }


    }
}
