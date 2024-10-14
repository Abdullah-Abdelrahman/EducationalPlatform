using Microsoft.AspNetCore.Http;

namespace EducationalPlatform.Data.Dto
{
    public class EditGeneralContentResult
    {
        public int ContentId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string ContentType { get; set; }

        //For Book , Video
        public IFormFile? ContentFile { get; set; }

        //For the Books
        public string? PathName { get; set; }

        //For Video
        public string? Url { get; set; }

    }
}
