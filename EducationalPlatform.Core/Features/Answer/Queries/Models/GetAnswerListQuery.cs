using EducationalPlatform.Core.Bases;
using EducationalPlatform.Core.Features.Answer.Queries.Results;
using MediatR;

namespace EducationalPlatform.Core.Features.Answer.Queries.Models
{
    public class GetAnswerListQuery : IRequest<Response<List<GetAnswerListResponse>>>
    {



    }
}
