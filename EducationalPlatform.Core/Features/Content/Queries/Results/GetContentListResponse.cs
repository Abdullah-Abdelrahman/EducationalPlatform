namespace EducationalPlatform.Core.Features.Content.Queries.Results
{
    public class GetContentListResponse
    {
        public int ContentId { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string ContentType { get; set; }
    }
}
