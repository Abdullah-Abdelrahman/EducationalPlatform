using AutoMapper;
using EducationalPlatform.Core.Bases;
using EducationalPlatform.Core.Features.Authorization.Commands.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
namespace EducationalPlatform.Core.Features.Authorization.Commands.Handlers
{
    public class RoleCommandHandler : ResponseHandler,
         IRequestHandler<AddRoleCommand, Response<string>>
    {
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;

        #region ctor
        public RoleCommandHandler(IMapper mapper, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _mapper = mapper;

        }
        #endregion







        public async Task<Response<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _roleManager.CreateAsync(new IdentityRole() { Name = request.RoleName });

            if (result.Succeeded)
            {
                return Created<string>($"{request.RoleName} : Role Created Successfuly");
            }
            else
            {
                return BadRequest<string>("Somthing Bad happened");
            }
        }
    }
}
