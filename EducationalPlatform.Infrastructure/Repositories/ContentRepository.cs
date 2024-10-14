using EducationalPlatform.Data.Dto;
using EducationalPlatform.Data.Entities;
using EducationalPlatform.Infrastructure.Abstracts;
using EducationalPlatform.Infrastructure.Bases;
using EducationalPlatform.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EducationalPlatform.Infrastructure.Repositories
{
    public class ContentRepository : GenericRepository<Content>, IContentRepository
    {
        private readonly DbSet<Content> _contentSet;
        private readonly DbSet<Video> _videos;
        private readonly DbSet<Book> _books;
        private readonly DbSet<Assignment> _assignments;

        public ContentRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _contentSet = dbContext.Set<Content>();
            _videos = dbContext.Set<Video>();
            _books = dbContext.Set<Book>();
            _assignments = dbContext.Set<Assignment>();

        }

        public async Task<string> AddBookAsync(Book book)
        {
            var result = await _books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
            if (result == null)
            {
                return "Cant Add";
            }
            else
            {
                return "Success";
            }
        }

        public async Task<string> AddVideoAsync(Video video)
        {
            var result = await _videos.AddAsync(video);
            await _dbContext.SaveChangesAsync();
            if (result == null)
            {
                return "Cant Add";
            }
            else
            {
                return "Success";
            }
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _books.FindAsync(id);
        }

        public async Task<Video> GetVideoByIdAsync(int id)
        {
            return await _videos.FindAsync(id);

        }

        public async Task<string> UpdateByTypeAsync(EditGeneralContentResult request)
        {
            if (request.ContentType == "Book")
            {
                var book = new Book()
                {
                    ContentId = request.ContentId,
                    Title = request.Title,
                    Description = request.Description,
                    CreatedAt = (DateTime)request.CreatedAt,
                    PathName = request.PathName

                };

                var result = _books.Update(book);
                await _dbContext.SaveChangesAsync();

                return "Success";

            }
            else if (request.ContentType == "Video")
            {
                var vid = new Video()
                {
                    ContentId = request.ContentId,
                    Title = request.Title,
                    Description = request.Description,
                    CreatedAt = (DateTime)request.CreatedAt,
                    Url = request.Url

                };

                var result = _videos.Update(vid);
                await _dbContext.SaveChangesAsync();

                return "Success";
            }
            else
            {
                return $"There is no General Content type = {request.ContentType}";
            }
        }
    }
}
