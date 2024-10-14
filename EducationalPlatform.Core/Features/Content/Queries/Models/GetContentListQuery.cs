using EducationalPlatform.Core.Bases;
using EducationalPlatform.Core.Features.Content.Queries.Results;
using MediatR;

namespace EducationalPlatform.Core.Features.Content.Queries.Models
{
    public class GetContentListQuery : IRequest<Response<List<GetContentListResponse>>>
    {

    }
}
