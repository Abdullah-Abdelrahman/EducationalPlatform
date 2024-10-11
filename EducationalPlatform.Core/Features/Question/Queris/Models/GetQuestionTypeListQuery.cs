using EducationalPlatform.Core.Bases;
using MediatR;

namespace EducationalPlatform.Core.Features.Question.Queris.Models
{
    public class GetQuestionTypeListQuery : IRequest<Response<List<string>>>
    {
    }
}
