using EducationalPlatform.Core.Bases;
using MediatR;

namespace EducationalPlatform.Core.Features.Enrollment.Commands.Models
{
    public class AddEnrollmentCommand : IRequest<Response<string>>
    {
        public string UserId { get; set; }

        public int CourseId { get; set; }

        public string Coupon { get; set; }
    }
}
