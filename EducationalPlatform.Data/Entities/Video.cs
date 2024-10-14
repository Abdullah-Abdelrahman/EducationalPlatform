using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationalPlatform.Data.Entities
{
    public class Video : Content
    {
        [NotMapped]
        public IFormFile? File { get; set; }

        public string Url { get; set; }
    }

}
