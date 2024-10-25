using AutoMapper;
using EducationalPlatform.Core.Bases;
using EducationalPlatform.Core.Features.AppUser.Commands.Models;
using EducationalPlatform.Service.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Identity;


using US = EducationalPlatform.Data.Entities;



namespace EducationalPlatform.Core.Features.AppUser.Commands.Handlers
{



    public class UserCommandHandler : ResponseHandler,
         IRequestHandler<AddUserCommand, Response<string>>,
         IRequestHandler<EditUserCommand, Response<string>>,
        IRequestHandler<DeleteUserCommand, Response<string>>,
        IRequestHandler<ChangeUserPasswordCommand, Response<string>>

    {

        private readonly IMapper _mapper;
        private readonly IAppUserService _appUserService;

        private readonly UserManager<US.AppUser> _userManager;

        public UserCommandHandler(IMapper mapper, IAppUserService appUserService, UserManager<US.AppUser> userManager)
        {
            _appUserService = appUserService;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {

            var user = _mapper.Map<AddUserCommand, US.AppUser>(request);

            var result = await _appUserService.AddUserAsync(user, request.Password);

            switch (result)
            {
                case "Success": return Success<string>(result);
                case "EmailAlredyExist": return BadRequest<string>(result);
                case "UserNameAlredyExist": return BadRequest<string>(result);
                case "UserCreatedSuccessfullyButNotAddedTo[user]Role": return BadRequest<string>(result);

            }

            return BadRequest<string>(result);
        }

        public async Task<Response<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);

            if (user == null)
            {
                return NotFound<string>($"ther is no user with id ={request.UserId}");
            }
            else
            {
                var userMapper = _mapper.Map(request, user);

                var NewuserNameExtist = _userManager.Users.Any(u => u.UserName == user.UserName && u.Id != user.Id);
                if (NewuserNameExtist)
                {
                    return BadRequest<string>("there is a user with the same UserName");

                }
                var NewEmailExtist = _userManager.Users.Any(u => u.Email == user.Email && u.Id != user.Id);
                if (NewEmailExtist)
                {
                    return BadRequest<string>("there is a user with the same Email");

                }
                var result = await _userManager.UpdateAsync(userMapper);

                if (result == IdentityResult.Success)
                {
                    return Success<string>("Success");
                }
                else
                {
                    return BadRequest<string>("Somthing bad happend");
                }
            }
        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var courseInDB = await _userManager.FindByIdAsync(request.UserId);


            if (courseInDB == null)
            {
                return NotFound<string>($"There is no user with  id ={request.UserId}");
            }
            else
            {

                var result = await _userManager.DeleteAsync(courseInDB);

                if (result == IdentityResult.Success)
                {
                    return Deleted<string>();
                }
                else
                {
                    return BadRequest<string>("Error Equired");
                }



            }
        }

        public async Task<Response<string>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);


            if (user == null)
            {
                return NotFound<string>($"there is no user with id ={request.UserId}");
            }
            else
            {
                var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);

                if (result == IdentityResult.Success)
                {
                    return Success<string>("Password Updateted successfuly");
                }
                else
                {
                    return BadRequest<string>("Somthing bad happend");
                }
            }
        }
    }
}
