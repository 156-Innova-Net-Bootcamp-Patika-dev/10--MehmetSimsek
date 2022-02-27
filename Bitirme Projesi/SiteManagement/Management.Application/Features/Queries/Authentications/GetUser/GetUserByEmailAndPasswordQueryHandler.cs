using AutoMapper;
using Management.Application.Models.Authentications;
using Management.Domain.Entities.Authentications;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Queries.Authentications.GetUser
{
    internal class GetUserByEmailAndPasswordQueryHandler : IRequestHandler<GetUserByEmailAndPasswordQuery,
        UserModel>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<Role> _roleManager;

        public GetUserByEmailAndPasswordQueryHandler(UserManager<User> userManager, IMapper mapper, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        public async Task<UserModel> Handle(GetUserByEmailAndPasswordQuery request, CancellationToken cancellationToken)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Email == request.Email);
            if (user is null)
            {
                return null;
            }

            var userModel = _mapper.Map<UserModel>(user);

            var userSigninResult = await _userManager.CheckPasswordAsync(user, request.Password);

            if (userSigninResult)
            {
                userModel.Roles = await _userManager.GetRolesAsync(user);
            }

            return userModel;
        }
        
    }
}
