using FluentValidation;
using Management.Domain.Entites.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Commands.Messages.AddMessage
{
    public class AddMessageValidator : AbstractValidator<Message>
    {
        public AddMessageValidator()
        {

        }
    }
}
