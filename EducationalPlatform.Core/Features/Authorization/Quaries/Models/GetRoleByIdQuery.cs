using EducationalPlatform.Core.Bases;
using EducationalPlatform.Core.Features.Authorization.Quaries.Results;
using MediatR;

namespace EducationalPlatform.Core.Features.Authorization.Quaries.Models
{
    public class GetRoleByIdQuery : IRequest<Response<GetRoleByIdResponse>>
    {

        public string RoleId { get; set; }

        public GetRoleByIdQuery(string id)
        {
            RoleId = id;
        }
    }
}
