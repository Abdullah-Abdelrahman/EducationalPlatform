using EducationalPlatform.Core.Bases;
using EducationalPlatform.Core.Features.Courses.Queries.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalPlatform.Core.Features.Courses.Queries.Models
{
    public class GetCourseByIdQuery:IRequest<Response<GetCourseByIdResponse>>
    {

        public int Id { get; set; }

        public GetCourseByIdQuery(int id)
        {
            Id = id;
        }
    }
}
