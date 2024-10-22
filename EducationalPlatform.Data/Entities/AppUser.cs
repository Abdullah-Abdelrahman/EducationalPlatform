using Microsoft.AspNetCore.Identity;

namespace EducationalPlatform.Data.Entities
{
    public class AppUser : IdentityUser
    {

        public string Name { get; set; }

        public decimal Balance { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Payment> Payments { get; set; }

        public AppUser()
        {
            Enrollments = new HashSet<Enrollment>();
            Payments = new HashSet<Payment>();
        }
    }

}
