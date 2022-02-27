using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Commands.Authentications.SignUpUser
{
    public class SignUpValidator : AbstractValidator<SignUpUserCommand>
    {
        public SignUpValidator()
        {
            RuleFor(u => u.Email).NotEmpty().WithMessage("Email address is required!");
            RuleFor(u => u.Password).NotEmpty().WithMessage("Password is required!");

        }
    }
}
