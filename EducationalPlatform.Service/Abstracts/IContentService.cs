using EducationalPlatform.Data.Dto;
using EducationalPlatform.Data.Entities;

namespace EducationalPlatform.Service.Abstracts
{
    public interface IContentService
    {
        public Task<string> AddGeneralContent(AddGeneralContentRequest request);

        public Task<string> DeleteContentById(int id);

        public Task<List<Content>> GetContentListAsync();


        public Task<GetGeneralContentResult> GetContentByIdAsync(int id);


        public Task<string> UpdateGeneralContentAsync(EditGeneralContentResult Content);

    }
}
