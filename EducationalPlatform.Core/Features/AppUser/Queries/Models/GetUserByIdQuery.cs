using EducationalPlatform.Core.Bases;
using EducationalPlatform.Core.Features.AppUser.Queries.Results;
using MediatR;

namespace EducationalPlatform.Core.Features.AppUser.Queries.Models
{
    public class GetUserByIdQuery : IRequest<Response<GetUserByIdResponse>>
    {

        public string Id { get; set; }

        public GetUserByIdQuery(string id)
        {
            Id = id;
        }
    }
}
