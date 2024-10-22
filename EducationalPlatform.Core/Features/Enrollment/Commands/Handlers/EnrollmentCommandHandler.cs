using AutoMapper;
using EducationalPlatform.Core.Bases;
using EducationalPlatform.Core.Features.Enrollment.Commands.Models;
using EducationalPlatform.Service.Abstracts;
using MediatR;

using En = EducationalPlatform.Data.Entities;
namespace EducationalPlatform.Core.Features.Enrollment.Commands.Handlers
{
    public class EnrollmentCommandHandler : ResponseHandler,
        IRequestHandler<AddEnrollmentCommand, Response<string>>
    {

        private readonly IMapper _mapper;

        private readonly IEnrollmentService _enrollmentService;
        public EnrollmentCommandHandler(IMapper mapper, IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddEnrollmentCommand request, CancellationToken cancellationToken)
        {
            var enrollmentMapper = _mapper.Map<En.Enrollment>(request);
            var result = await _enrollmentService.AddEnrollment(enrollmentMapper);
            if (result == "Success")
            {
                return Created<string>("Added successfuly");
            }
            else
            {
                return BadRequest<string>("Somthing bad happened");
            }
        }
    }
}
