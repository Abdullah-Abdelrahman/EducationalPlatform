using AutoMapper;
using EducationalPlatform.Core.Bases;
using EducationalPlatform.Core.Features.Content.Queries.Models;
using EducationalPlatform.Core.Features.Content.Queries.Results;
using EducationalPlatform.Data.Dto;
using EducationalPlatform.Service.Abstracts;
using MediatR;

namespace EducationalPlatform.Core.Features.Content.Queries.Handlers
{
    public class GeneralContentQueryHandler : ResponseHandler,
        IRequestHandler<GetContentListQuery, Response<List<GetContentListResponse>>>,
        IRequestHandler<GetContentTypeListQuery, Response<List<string>>>,
        IRequestHandler<GetGeneralContentByIdQuery, Response<GetGeneralContentResult>>


    {

        #region Fields
        private readonly IContentService _contentService;

        private readonly IMapper _mapper;
        #endregion

        public GeneralContentQueryHandler(IMapper mapper, IContentService contentService)
        {
            _contentService = contentService;
            _mapper = mapper;
        }

        public async Task<Response<List<GetContentListResponse>>> Handle(GetContentListQuery request, CancellationToken cancellationToken)
        {
            var ContentList = await _contentService.GetContentListAsync();


            var ContentListMap = _mapper.Map<List<GetContentListResponse>>(source: ContentList);


            return Success<List<GetContentListResponse>>(ContentListMap);
        }

        public async Task<Response<List<string>>> Handle(GetContentTypeListQuery request, CancellationToken cancellationToken)
        {
            List<string> TypeList = new List<string>();

            TypeList.Add("Book");
            TypeList.Add("Video");
            TypeList.Add("Quiz");
            TypeList.Add("Assignment");


            return Success<List<string>>(TypeList);
        }

        public async Task<Response<GetGeneralContentResult>> Handle(GetGeneralContentByIdQuery request, CancellationToken cancellationToken)
        {
            var content = await _contentService.GetContentByIdAsync(request.Id);

            return Success<GetGeneralContentResult>(content);
        }
    }
}
