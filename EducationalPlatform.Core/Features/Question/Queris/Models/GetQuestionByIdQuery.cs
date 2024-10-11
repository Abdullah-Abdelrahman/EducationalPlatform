using EducationalPlatform.Core.Bases;
using EducationalPlatform.Data.Dto;
using MediatR;

namespace EducationalPlatform.Core.Features.Question.Queris.Models
{
    public class GetQuestionByIdQuery : IRequest<Response<GetQuestionResult>>
    {
        public int Id { get; set; }

        public GetQuestionByIdQuery(int id)
        {
            Id = id;
        }
    }
}
