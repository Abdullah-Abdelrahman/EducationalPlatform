using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalPlatform.Data.Entities
{
    public class AppUser:IdentityUser
    {
      
        public string Name { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Payment> Payments { get; set; }

        public AppUser() { 
            Enrollments = new HashSet<Enrollment>();
            Payments = new HashSet<Payment>();
        }   
    }

}
