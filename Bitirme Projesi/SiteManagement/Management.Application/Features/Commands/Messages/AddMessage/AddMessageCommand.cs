using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Commands.Messages.AddMessage
{
    public class AddMessageCommand : IRequest<int>
    {
        public int RecieverId { get; set; }
        public int SenderId { get; set; }
        public string Text { get; set; }


    }
}
