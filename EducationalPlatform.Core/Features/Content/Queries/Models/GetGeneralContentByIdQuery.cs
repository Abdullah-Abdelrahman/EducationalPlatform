using EducationalPlatform.Core.Bases;
using EducationalPlatform.Data.Dto;
using MediatR;

namespace EducationalPlatform.Core.Features.Content.Queries.Models
{
    public class GetGeneralContentByIdQuery : IRequest<Response<GetGeneralContentResult>>
    {
        public int Id { get; set; }

        public GetGeneralContentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
