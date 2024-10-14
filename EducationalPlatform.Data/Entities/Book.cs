using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationalPlatform.Data.Entities
{
    public class Book : Content
    {
        [NotMapped]
        public IFormFile? File { get; set; }
        public string PathName { get; set; }
    }

}
