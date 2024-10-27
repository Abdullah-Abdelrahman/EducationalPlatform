using EducationalPlatform.Core.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;

namespace EducationalPlatform.Core.Features.Courses.Commands.Models
{
    public class AddCourseCommand : IRequest<Response<string>>
    {

        public string Name { get; set; }

        public string Description { get; set; }

        //Image
        public IFormFile? ImageFile { get; set; }

        [JsonIgnore]
        public string? WebRootPath { get; set; }

        public List<int>? ContentsId { get; set; }


    }


}
