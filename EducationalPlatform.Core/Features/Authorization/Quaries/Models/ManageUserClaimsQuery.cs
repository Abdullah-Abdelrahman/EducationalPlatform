using EducationalPlatform.Core.Bases;
using EducationalPlatform.Data.Dto;
using MediatR;

namespace EducationalPlatform.Core.Features.Authorization.Quaries.Models
{
    public class ManageUserClaimsQuery : IRequest<Response<ManageUserClaimsResult>>
    {

        public string UserId { get; set; }

        public ManageUserClaimsQuery(string id)
        {
            UserId = id;
        }
    }
}
