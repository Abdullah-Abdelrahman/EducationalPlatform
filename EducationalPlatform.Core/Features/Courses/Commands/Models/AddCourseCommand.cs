using EducationalPlatform.Core.Bases;
using EducationalPlatform.Data.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace EducationalPlatform.Core.Features.Courses.Commands.Models
{
    public class AddCourseCommand : IRequest<Response<string>>
    {

        public string Name { get; set; }

        public string Description { get; set; }
        //Image
        public IFormFile? ImageFile { get; set; }


        public string? WebRootPath { get; set; }

        public List<CourseContentDto>? Contents { get; set; }


    }


}
