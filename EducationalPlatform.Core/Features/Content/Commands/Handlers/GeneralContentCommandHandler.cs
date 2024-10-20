using AutoMapper;
using EducationalPlatform.Core.Bases;
using EducationalPlatform.Core.Features.Content.Commands.Models;
using EducationalPlatform.Service.Abstracts;
using MediatR;

namespace EducationalPlatform.Core.Features.Content.Commands.Handlers
{
    public class GeneralContentCommandHandler : ResponseHandler,
         IRequestHandler<AddGeneralContentCommand, Response<string>>,
        IRequestHandler<DeleteContentCommand, Response<string>>,
         IRequestHandler<EditGeneralContentCommand, Response<string>>

    {

        private readonly IMapper _mapper;
        private readonly IContentService _contentService;

        public GeneralContentCommandHandler(IMapper mapper, IContentService contentService)
        {
            _contentService = contentService;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddGeneralContentCommand request, CancellationToken cancellationToken)
        {

            request.PathName = request.webRootPath;
            var result = await _contentService.AddGeneralContent(request);

            if (result == "Success")
            {
                return Created<string>("Added successfuly");
            }
            else
            {
                return BadRequest<string>(result);
            }
        }

        public async Task<Response<string>> Handle(DeleteContentCommand request, CancellationToken cancellationToken)
        {
            var result = await _contentService.DeleteContentById(request.Id);

            if (result == "Success")
            {
                return Success<string>(result);
            }
            else if (result == "NotFound")
            {
                return NotFound<string>($"No Question with id = {request.Id}");
            }
            else
            {
                return BadRequest<string>(result);
            }
        }

        public async Task<Response<string>> Handle(EditGeneralContentCommand request, CancellationToken cancellationToken)
        {
            var result = await _contentService.UpdateGeneralContentAsync(request);

            if (result == "Success")
            {
                return Success<string>(result);
            }
            else
            {
                return BadRequest<string>(result);
            }

        }
    }
}
