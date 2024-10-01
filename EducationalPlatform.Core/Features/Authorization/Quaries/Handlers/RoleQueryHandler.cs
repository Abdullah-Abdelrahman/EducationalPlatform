using AutoMapper;
using EducationalPlatform.Core.Bases;
using EducationalPlatform.Core.Features.Authorization.Quaries.Models;
using EducationalPlatform.Core.Features.Authorization.Quaries.Results;
using EducationalPlatform.Service.Abstracts;
using MediatR;

namespace EducationalPlatform.Core.Features.Authorization.Quaries.Handlers
{
    public class RoleQueryHandler : ResponseHandler,
        IRequestHandler<GetRoleListQuery, Response<List<GetRoleListResponse>>>,
         IRequestHandler<GetRoleByIdQuery, Response<GetRoleByIdResponse>>
    {

        #region

        private readonly IMapper _mapper;

        private readonly IAuthorizationService _authorizationService;
        #endregion

        public RoleQueryHandler(IMapper mapper, IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
            _mapper = mapper;
        }

        public async Task<Response<List<GetRoleListResponse>>> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
        {
            var roles = await _authorizationService.GetRolesList();

            var result = _mapper.Map<List<GetRoleListResponse>>(roles);
            return Success<List<GetRoleListResponse>>(result);
        }

        public async Task<Response<GetRoleByIdResponse>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await _authorizationService.GetRoleById(request.RoleId);

            if (role == null)
            {
                return NotFound<GetRoleByIdResponse>($"there is no Role with id = {request.RoleId}");
            }
            else
            {
                var result = _mapper.Map<GetRoleByIdResponse>(role);
                return Success<GetRoleByIdResponse>(result);
            }
        }
    }
}
