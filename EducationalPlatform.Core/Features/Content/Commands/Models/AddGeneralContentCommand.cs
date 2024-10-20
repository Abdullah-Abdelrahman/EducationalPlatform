using EducationalPlatform.Core.Bases;
using EducationalPlatform.Data.Dto;
using MediatR;
using System.Text.Json.Serialization;

namespace EducationalPlatform.Core.Features.Content.Commands.Models
{
    public class AddGeneralContentCommand : AddGeneralContentRequest, IRequest<Response<string>>
    {

        [JsonIgnore]
        public string? webRootPath { get; set; }
    }
}
