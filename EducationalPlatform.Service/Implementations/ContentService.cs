using EducationalPlatform.Data.Dto;
using EducationalPlatform.Data.Entities;
using EducationalPlatform.Infrastructure.Abstracts;
using EducationalPlatform.Service.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace EducationalPlatform.Service.Implementations
{
    public class ContentService : IContentService
    {
        private readonly IContentRepository _contentRepository;

        private readonly IFileService _FileService;

        public ContentService(IContentRepository contentRepository, IFileService FileService)
        {

            _contentRepository = contentRepository;
            _FileService = FileService;
        }
        public async Task<string> AddGeneralContent(AddGeneralContentRequest request)
        {
            if (request.ContentType == "Book")
            {

                if (request.ContentFile == null)
                {
                    return "File is Null";
                }
                if (request.PathName == null)
                {
                    return "PathName is null";
                }
                if (request.PathName == "")
                {
                    return "PathName is Empty";
                }




                var newBook = new Book()
                {
                    Title = request.Title,
                    Description = request.Description,
                    CreatedAt = DateTime.Now,
                    ContentType = request.ContentType,
                    File = request.ContentFile,
                    PathName = (await _FileService.UploadFile(request.ContentFile, request.PathName))
                };

                var result = await _contentRepository.AddBookAsync(newBook);

                if (result == "Success")
                {
                    return "Success";
                }
                else if (result == "Cant Add")
                {
                    return "Cant Add";
                }
                else
                {
                    return "somthing bad Happened";
                }
            }
            else if (request.ContentType == "Video")
            {
                if (request.ContentFile == null)
                {
                    return "File is Null";
                }
                if (request.PathName == null)
                {
                    return "PathName is null";
                }
                if (request.Url == "")
                {
                    return "Url is Empty";
                }

                var newVideo = new Video()
                {
                    Title = request.Title,
                    Description = request.Description,
                    CreatedAt = DateTime.Now,
                    ContentType = request.ContentType,
                    File = request.ContentFile,
                    Url = request.Url
                };

                var result = await _contentRepository.AddVideoAsync(newVideo);

                if (result == "Success")
                {
                    return "Success";
                }
                else if (result == "Cant Add")
                {
                    return "Cant Add";
                }
                else
                {
                    return "somthing bad Happened";
                }

            }
            else
            {
                return $"There is No type = {request.ContentType}";
            }
        }

        public async Task<string> DeleteContentById(int id)
        {
            var content = await _contentRepository.GetByIdAsync(id);

            if (content == null)
            {
                return "NotFound";
            }
            else
            {
                try
                {
                    await _contentRepository.DeleteAsync(content);

                    return "Success";
                }
                catch (Exception ex)
                {
                    return "An error wcure while tring to delete the entity";
                }



            }
        }

        public async Task<bool> ExistByIdAsync(int id)
        {
            if ((await _contentRepository.GetByIdAsync(id)) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<GetGeneralContentResult> GetContentByIdAsync(int id)
        {
            var response = new GetGeneralContentResult();
            var content = await _contentRepository.GetByIdAsync(id);

            if (content != null)
            {
                try
                {
                    response.ContentId = content.ContentId;
                    response.Title = content.Title;
                    response.Description = content.Description;
                    response.CreatedAt = content.CreatedAt;
                    response.ContentType = content.ContentType;



                    if (content.ContentType == "Book")
                    {
                        var book = await _contentRepository.GetBookByIdAsync(content.ContentId);

                        response.PathName = book.PathName;

                        if (response.PathName != null)
                        {
                            var Fileresponse = await _FileService.GetFileAsync(response.PathName);
                            if (Fileresponse != null)
                            {
                                response.formFile = Fileresponse;

                            }
                            else
                            {
                                // Handle error, for example, return null or throw an exception
                                return null;
                            }
                        }


                    }
                    else if (content.ContentType == "Video")
                    {
                        var vid = await _contentRepository.GetVideoByIdAsync(content.ContentId);
                        response.Url = vid.Url;
                    }
                }
                catch (Exception ex)
                {
                    //error
                }

            }


            return response;
        }

        public async Task<List<Content>> GetContentListAsync()
        {
            var list = await _contentRepository.GetTableNoTracking().ToListAsync();


            return list;
        }

        public async Task<string> UpdateGeneralContentAsync(EditGeneralContentResult request)
        {
            var transact = _contentRepository.BeginTransaction();
            try
            {
                var result = await _contentRepository.UpdateByTypeAsync(request);

                await transact.CommitAsync();
                return result;

            }
            catch
            {
                await transact.RollbackAsync();
                return "Falied";
            }
        }
    }
}
