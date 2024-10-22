using EducationalPlatform.Core.Bases;
using EducationalPlatform.Core.Features.Email.Commands.Models;
using EducationalPlatform.Service.Abstracts;
using MediatR;

namespace EducationalPlatform.Core.Features.Email.Commands.Handlers
{
    public class EmailCommandHandler : ResponseHandler,
        IRequestHandler<SendEmailCommand, Response<string>>
    {

        private readonly IEmailService _emailService;
        public EmailCommandHandler(IEmailService emailService)
        {

            _emailService = emailService;
        }

        public async Task<Response<string>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            var result = await _emailService.SendEmailAsync(request.Email, request.Message);

            if (result == "Success")
            {
                return Success(result);
            }
            else
            {
                return BadRequest<string>();
            }
        }
    }
}
