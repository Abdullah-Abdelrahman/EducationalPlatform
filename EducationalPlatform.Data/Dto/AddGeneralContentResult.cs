using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;

namespace EducationalPlatform.Data.Dto
{
    public class AddGeneralContentResult
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string ContentType { get; set; }

        //For Book , Video
        public IFormFile? ContentFile { get; set; }

        //For the Books
        [JsonIgnore]
        public string? PathName { get; set; }

        //For Video
        public string? Url { get; set; }


    }
}
