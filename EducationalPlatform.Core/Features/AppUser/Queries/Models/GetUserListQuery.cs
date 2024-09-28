using EducationalPlatform.Core.Bases;
using EducationalPlatform.Core.Features.AppUser.Queries.Results;
using MediatR;

namespace EducationalPlatform.Core.Features.AppUser.Queries.Models
{
    public class GetUserListQuery : IRequest<Response<List<GetUserListResponse>>>
    {

    }
}
