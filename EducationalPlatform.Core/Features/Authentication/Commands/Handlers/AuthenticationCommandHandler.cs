using AutoMapper;
using EducationalPlatform.Core.Bases;
using EducationalPlatform.Core.Features.Authentication.Commands.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Au = EducationalPlatform.Service.Abstracts;
using US = EducationalPlatform.Data.Entities;
namespace EducationalPlatform.Core.Features.Authentication.Commands.Handlers
{
    public class AuthenticationCommandHandler : ResponseHandler,
         IRequestHandler<SignInCommand, Response<string>>
    {


        private readonly IMapper _mapper;
        private readonly UserManager<US.AppUser> _userManager;
        private readonly SignInManager<US.AppUser> _signInManager;
        private readonly Au.IAuthenticationService _authenticationService;
        public AuthenticationCommandHandler(IMapper mapper,
            UserManager<US.AppUser> userManager,
            SignInManager<US.AppUser> signInManager,
            Au.IAuthenticationService authenticationService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _authenticationService = authenticationService;
        }
        public async Task<Response<string>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                return BadRequest<string>("There is no user with this email");
            }
            else
            {
                var result = await _userManager.CheckPasswordAsync(user, request.Password);

                if (result == false)
                {
                    return BadRequest<string>("password and Email MissMatch");
                }
                else
                {
                    //Login
                    await _signInManager.SignInAsync(user, false);
                    // biuld token



                    //return the token
                    return Success<string>(await _authenticationService.GetJWTtoken(user));
                }

            }


        }
    }
}
