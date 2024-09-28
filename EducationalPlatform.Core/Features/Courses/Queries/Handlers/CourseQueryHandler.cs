using AutoMapper;
using EducationalPlatform.Core.Bases;
using EducationalPlatform.Core.Features.Courses.Queries.Models;
using EducationalPlatform.Core.Features.Courses.Queries.Results;
using EducationalPlatform.Data.Entities;
using EducationalPlatform.Service.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalPlatform.Core.Features.Courses.Queries.Handlers
{
    public class CourseQueryHandler :ResponseHandler, IRequestHandler<GetCoursesQuery,Response<List<GetCoursesResponse>>>,
        IRequestHandler<GetCourseByIdQuery, Response<GetCourseByIdResponse>>
    {

        #region Fields
        private readonly ICourseService _courseService;

        private readonly IMapper _mapper;
        #endregion

        public CourseQueryHandler(ICourseService courseService,IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }



        public async Task<Response< List<GetCoursesResponse>>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
        {
            var CorseList = await _courseService.GetCoursesListAsync();

            var CorseListMapper = _mapper.Map<List<GetCoursesResponse>>(CorseList);

            return Success(CorseListMapper);
        }

        public async Task<Response<GetCourseByIdResponse>> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var course = await _courseService.GetCourseByIdAsync(request.Id);


            if(course == null)
            {
                return NotFound<GetCourseByIdResponse>("Course Not Found");
            }
            else
            {
                var CorseMapper = _mapper.Map<GetCourseByIdResponse>(course);
                return Success(CorseMapper);
            }
        }
    }
}
