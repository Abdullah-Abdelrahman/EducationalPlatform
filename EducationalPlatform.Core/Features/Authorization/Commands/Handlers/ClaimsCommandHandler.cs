using EducationalPlatform.Core.Bases;
using EducationalPlatform.Core.Features.Authorization.Commands.Models;
using EducationalPlatform.Service.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EducationalPlatform.Core.Features.Authorization.Commands.Handlers
{
    internal class ClaimsCommandHandler : ResponseHandler,
         IRequestHandler<UpdateUserClaimsCommand, Response<string>>
    {

        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly IAuthorizationService _authorizationService;
        #region ctor
        public ClaimsCommandHandler(
            RoleManager<IdentityRole> roleManager,
            IAuthorizationService authorizationService)
        {
            _roleManager = roleManager;
            _authorizationService = authorizationService;
        }

        public async Task<Response<string>> Handle(UpdateUserClaimsCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.UpdateUserClaims(request);
            switch (result)
            {
                case "UserIsNull": return NotFound<string>("User NOT FOUND");
                case "FailedToRemoveOldClaims": return BadRequest<string>("FailedToRemoveOldClaims");
                case "FailedToAddNewClaims": return BadRequest<string>("FailedToAddNewClaims");
                case "FailedToUpdateClaims": return BadRequest<string>("FailedToUpdateClaims");
            }
            return Success<string>("Success");
        }
        #endregion

    }
}
