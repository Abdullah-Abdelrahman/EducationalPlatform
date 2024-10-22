using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationalPlatform.Data.Entities
{
    public class EnrollmentContentProgress
    {
        [Key]
        public int EnrollmentId { get; set; }

        public int ContentId { get; set; }

        public int Progress { get; set; }


        [ForeignKey("EnrollmentId")]
        public Enrollment Enrollment { get; set; }

        [ForeignKey("ContentId")]
        public Content Content { get; set; }

    }
}
