using EducationalPlatform.Data.Dto;
using EducationalPlatform.Data.Entities;
using EducationalPlatform.Infrastructure.Bases;

namespace EducationalPlatform.Infrastructure.Abstracts
{
    public interface IContentRepository : IGenericRepository<Content>
    {
        public Task<string> AddBookAsync(Book book);

        public Task<string> AddVideoAsync(Video video);

        public Task<Book> GetBookByIdAsync(int id);

        public Task<Video> GetVideoByIdAsync(int id);

        public Task<string> UpdateByTypeAsync(EditGeneralContentResult request);

    }
}
