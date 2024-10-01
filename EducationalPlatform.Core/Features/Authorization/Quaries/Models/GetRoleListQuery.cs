using EducationalPlatform.Core.Bases;
using EducationalPlatform.Core.Features.Authorization.Quaries.Results;
using MediatR;

namespace EducationalPlatform.Core.Features.Authorization.Quaries.Models
{
    public class GetRoleListQuery : IRequest<Response<List<GetRoleListResponse>>>
    {
    }
}
