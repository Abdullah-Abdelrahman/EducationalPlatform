using AutoMapper;
using EducationalPlatform.Core.Bases;
using EducationalPlatform.Core.Features.AppUser.Commands.Models;
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
        private readonly UserManager<US.AppUser> _userManager;

        public UserCommandHandler(IMapper mapper, UserManager<US.AppUser> userManager)
        {

            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {

            var user = _mapper.Map<AddUserCommand, US.AppUser>(request);


            //if email Exist before

            var Emailresult = await _userManager.FindByEmailAsync(user.Email);

            if (Emailresult == null)
            {
                var UserNameresult = await _userManager.FindByNameAsync(user.UserName);

                if (UserNameresult == null)
                {

                    var result = await _userManager.CreateAsync(user, request.Password);

                    if (result == IdentityResult.Success)
                    {
                        var addRoleResult = await _userManager.AddToRoleAsync(user, "User");

                        if (addRoleResult == IdentityResult.Success)
                        {
                            return Created<string>("User created Successfuly and added to [user] role");

                        }
                        else
                        {
                            return Created<string>("User created Successfuly but not added to [user] role");
                        }
                    }
                    else
                    {
                        return BadRequest<string>("Somthing Bad happend");
                    }

                }
                else
                {
                    return BadRequest<string>("userName Alredy Exist");
                }
            }
            else
            {
                return BadRequest<string>("Email Alredy Exist");
            }


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
