using EducationalPlatform.Core.Bases;
using EducationalPlatform.Data.Dto;
using MediatR;

namespace EducationalPlatform.Core.Features.Authorization.Commands.Models
{
    public class UpdateUserClaimsCommand : UpdateUserClaimsRequest, IRequest<Response<string>>
    {
    }
}
