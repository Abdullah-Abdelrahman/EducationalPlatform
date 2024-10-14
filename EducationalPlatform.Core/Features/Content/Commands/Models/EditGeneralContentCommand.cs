using EducationalPlatform.Core.Bases;
using EducationalPlatform.Data.Dto;
using MediatR;

namespace EducationalPlatform.Core.Features.Content.Commands.Models
{
    public class EditGeneralContentCommand : EditGeneralContentResult, IRequest<Response<string>>
    {


    }
}
