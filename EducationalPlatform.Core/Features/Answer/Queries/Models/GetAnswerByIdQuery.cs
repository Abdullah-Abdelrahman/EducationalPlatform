using EducationalPlatform.Core.Bases;
using EducationalPlatform.Core.Features.Answer.Queries.Results;
using MediatR;

namespace EducationalPlatform.Core.Features.Answer.Queries.Models
{
    public class GetAnswerByIdQuery : IRequest<Response<GetAnswerByIdResponse>>
    {

        public int Id { get; set; }

        public GetAnswerByIdQuery(int id)
        {
            Id = id;
        }
    }
}
