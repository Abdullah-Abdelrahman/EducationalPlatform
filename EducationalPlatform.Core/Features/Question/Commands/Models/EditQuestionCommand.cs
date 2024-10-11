using EducationalPlatform.Core.Bases;
using EducationalPlatform.Data.Dto;
using MediatR;

namespace EducationalPlatform.Core.Features.Question.Commands.Models
{
    public class EditQuestionCommand : EditQuestionResult, IRequest<Response<string>>
    {



    }
}
