using EducationalPlatform.Core.Bases;
using EducationalPlatform.Core.Features.Authorization.Quaries.Models;
using EducationalPlatform.Data.Dto;
using EducationalPlatform.Service.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Identity;
using US = EducationalPlatform.Data.Entities;


namespace EducationalPlatform.Core.Features.Authorization.Quaries.Handlers
{
    public class ClaimsQueryHandler : ResponseHandler,
        IRequestHandler<ManageUserClaimsQuery, Response<ManageUserClaimsResult>>
    {

        #region Fileds
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<US.AppUser> _userManager;
        #endregion

        public ClaimsQueryHandler(IAuthorizationService authorizationService, UserManager<US.AppUser> userManager)
        {
            _authorizationService = authorizationService;
            _userManager = userManager;
        }


        public async Task<Response<ManageUserClaimsResult>> Handle(ManageUserClaimsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null) return NotFound<ManageUserClaimsResult>();
            var result = await _authorizationService.ManageUserClaimData(user);
            return Success(result);
        }


    }
}
