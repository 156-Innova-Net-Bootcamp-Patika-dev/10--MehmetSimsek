using Management.Application.Features.Commands.Authentications.SignUpUser;
using Management.Application.Features.Queries.Authentications.GetUser;
using Management.Application.Models.Authentications;
using Management.Application.Settings;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Management.Api.Controllers.AuthenticationControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly JwtSettings _jwtSettings;

        public AuthsController(IMediator mediator, IOptionsSnapshot<JwtSettings> jwtSettings)
        {
            _mediator = mediator;
            _jwtSettings = jwtSettings.Value;
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpUserCommand signUpUserCommand)
        {
            //user sign up
            var signUpResult = await _mediator.Send(signUpUserCommand);
            if (signUpResult != 0)
                return Ok();

            return BadRequest("User cannot be created1");
      

        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(string email, string password)
        {
            //user sign in

            var userToSignIn = new GetUserByEmailAndPasswordQuery(email, password);
            var userModel = await _mediator.Send(userToSignIn);
            if (userModel != null)
                return Ok(GenerateJwt(userModel));

            return BadRequest("Email or password is invalid!");
        }

        private string GenerateJwt(UserModel userModel)
        {
            //To Get Token.
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userModel.Id.ToString()),
                new Claim(ClaimTypes.Name, userModel.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier,userModel.Id.ToString()),
            };

            var roleClaims = userModel.Roles.Select(r => new Claim(ClaimTypes.Role, r));
            claims.AddRange(roleClaims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_jwtSettings.ExpirationInDays));

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Issuer,
                claims,
                expires:expires,
                signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
