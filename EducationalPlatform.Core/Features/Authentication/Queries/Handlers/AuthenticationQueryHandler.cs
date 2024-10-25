using EducationalPlatform.Core.Bases;
using EducationalPlatform.Core.Features.Authentication.Queries.Models;
using EducationalPlatform.Service.Abstracts;
using MediatR;

namespace EducationalPlatform.Core.Features.Authentication.Queries.Handlers
{
    public class AuthenticationQueryHandler : ResponseHandler,
         IRequestHandler<ConfirmEmailQuery, Response<string>>
    {

        private readonly IAuthenticationService _authenticationService;

        public AuthenticationQueryHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        public async Task<Response<string>> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.ConfirmEmail(request.userId, request.code);
            if (result == "Success")
            {
                return Success<string>(result);
            }
            return BadRequest<string>(result);
        }
    }
}
