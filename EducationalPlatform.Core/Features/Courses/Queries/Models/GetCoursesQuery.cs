using EducationalPlatform.Core.Bases;
using EducationalPlatform.Core.Features.Courses.Queries.Results;
using EducationalPlatform.Data.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalPlatform.Core.Features.Courses.Queries.Models
{
    public class GetCoursesQuery : IRequest<Response< List<GetCoursesResponse>>>
    {
    }
}
