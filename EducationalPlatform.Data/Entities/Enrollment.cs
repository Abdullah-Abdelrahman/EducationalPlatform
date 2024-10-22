using System.ComponentModel.DataAnnotations.Schema;

namespace EducationalPlatform.Data.Entities
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public string CompletionStatus { get; set; }

        public string Coupon { get; set; }

        public decimal FinalPrice { get; set; }

        public List<EnrollmentContentProgress> CourseContentsProgress { get; set; }

        public string UserId { get; set; }

        public int CourseId { get; set; }

        [ForeignKey("UserId")]
        public AppUser User { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        public Enrollment()
        {
            CourseContentsProgress = new List<EnrollmentContentProgress>();
        }
    }

}
