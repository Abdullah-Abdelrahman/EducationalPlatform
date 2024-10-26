using AutoMapper;
using EducationalPlatform.Core.Bases;
using EducationalPlatform.Core.Features.Courses.Commands.Models;
using EducationalPlatform.Data.Entities;
using EducationalPlatform.Service.Abstracts;
using MediatR;

namespace EducationalPlatform.Core.Features.Courses.Commands.Handlers
{
    public class CourseCommandHandler : ResponseHandler,
        IRequestHandler<AddCourseCommand, Response<string>>,
        IRequestHandler<EditCourseCommand, Response<string>>,
         IRequestHandler<DeleteCourseCommand, Response<string>>
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;
        public CourseCommandHandler(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }
        public async Task<Response<string>> Handle(AddCourseCommand request, CancellationToken cancellationToken)
        {
            var coursMapper = _mapper.Map<Course>(request);
            var result = await _courseService.AddCourse(coursMapper, request.Contents);

            if (result == "Exist")
            {
                return UnprocessableEntity<string>("Name Exist Befor");
            }
            else if (result == "Success")
            {
                return Created<string>("Added successfuly");
            }
            else
            {
                return BadRequest<string>("Somthing bad happened");
            }

        }

        public async Task<Response<string>> Handle(EditCourseCommand request, CancellationToken cancellationToken)
        {

            var courseInDB = await _courseService.GetCourseByIdAsync(request.Id);


            if (courseInDB == null)
            {
                return NotFound<string>("There is no Course with this id");
            }
            else
            {
                var coursMapper = _mapper.Map<Course>(request);
                var result = await _courseService.UpdateAsync(coursMapper);

                if (result == "Success")
                {
                    return Success<string>($"Updated successfuly {coursMapper.CourseId}");
                }
                else
                {
                    return BadRequest<string>("Error Equired");
                }



            }
        }

        public async Task<Response<string>> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var courseInDB = await _courseService.GetCourseByIdAsync(request.Id);


            if (courseInDB == null)
            {
                return NotFound<string>("There is no Course with this id");
            }
            else
            {

                var result = await _courseService.DeleteAsync(courseInDB);

                if (result == "Success")
                {
                    return Deleted<string>();
                }
                else
                {
                    return BadRequest<string>("Error Equired");
                }



            }
        }
    }
}
