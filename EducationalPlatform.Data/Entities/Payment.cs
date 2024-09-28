using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalPlatform.Data.Entities
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public string Method { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Discount { get; set; }

       
        public string UserId { get; set; }
        public int CourseId { get; set; }

        [ForeignKey("UserId")]
        public AppUser User { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }
    }

}
