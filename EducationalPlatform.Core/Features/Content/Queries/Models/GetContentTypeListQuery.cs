using EducationalPlatform.Core.Bases;
using MediatR;

namespace EducationalPlatform.Core.Features.Content.Queries.Models
{
    public class GetContentTypeListQuery : IRequest<Response<List<string>>>
    {
    }
}
