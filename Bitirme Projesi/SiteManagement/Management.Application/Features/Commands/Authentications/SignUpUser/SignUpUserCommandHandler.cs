using AutoMapper;
using Management.Domain.Entities.Authentications;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Commands.Authentications.SignUpUser
{
    public class SignUpUserCommandHandler : IRequestHandler<SignUpUserCommand, int>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<Role> _roleManager;

        public SignUpUserCommandHandler(UserManager<User> userManager, IMapper mapper, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        public async Task<int> Handle(SignUpUserCommand request, CancellationToken cancellationToken)
        {
            var userToSignUp = _mapper.Map<User>(request);
            userToSignUp.UserName = request.Email;
            var signUpResult = await _userManager.CreateAsync(userToSignUp,request.Password);
            if (signUpResult.Succeeded)
            {
                var user = _userManager.Users.SingleOrDefault(u => u.Email == request.Email);
                return user.Id;
            }
            return 0;

        }
    }
}
