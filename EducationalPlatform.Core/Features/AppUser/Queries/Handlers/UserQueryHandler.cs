using AutoMapper;
using EducationalPlatform.Core.Bases;
using EducationalPlatform.Core.Features.AppUser.Queries.Models;
using EducationalPlatform.Core.Features.AppUser.Queries.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;


using US = EducationalPlatform.Data.Entities;


namespace EducationalPlatform.Core.Features.AppUser.Queries.Handlers
{
    public class UserQueryHandler : ResponseHandler,
        IRequestHandler<GetUserListQuery, Response<List<GetUserListResponse>>>,
        IRequestHandler<GetUserByIdQuery, Response<GetUserByIdResponse>>

    {

        #region Fields
        private readonly UserManager<US.AppUser> _userManager;

        private readonly IMapper _mapper;
        #endregion

        public UserQueryHandler(UserManager<US.AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<Response<List<GetUserListResponse>>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var usersMaper = _mapper.Map<List<GetUserListResponse>>(_userManager.Users.ToList());
            return Success(usersMaper);
        }

        public async Task<Response<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var userMaper = _mapper.Map<GetUserByIdResponse>(await _userManager.FindByIdAsync(request.Id));

            if (userMaper == null)
            {
                return NotFound<GetUserByIdResponse>($"there is no user with id = {request.Id}");
            }
            else
            {
                return Success(userMaper);
            }
        }
    }
}
