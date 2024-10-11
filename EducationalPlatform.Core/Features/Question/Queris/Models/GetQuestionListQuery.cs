using EducationalPlatform.Core.Bases;
using EducationalPlatform.Core.Features.Question.Queris.Results;
using MediatR;

namespace EducationalPlatform.Core.Features.Question.Queris.Models
{
    public class GetQuestionListQuery : IRequest<Response<List<GetQuestionListResponse>>>
    {
    }
}
