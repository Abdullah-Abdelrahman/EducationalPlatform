namespace EducationalPlatform.Data.Dto
{
    public class GetGeneralContentResult
    {

        public int ContentId { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string ContentType { get; set; }

        //For video only

        public string? Url { get; set; }

        //For book only
        public string? PathName { get; set; }


    }
}
