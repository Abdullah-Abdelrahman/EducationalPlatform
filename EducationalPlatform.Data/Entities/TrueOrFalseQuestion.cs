using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalPlatform.Data.Entities
{
    public class TrueOrFalseQuestion:Question
    {

        public int correctAnswerId { get; set; }

        public ICollection<Answer> answerList { get; set; }
    }
}
