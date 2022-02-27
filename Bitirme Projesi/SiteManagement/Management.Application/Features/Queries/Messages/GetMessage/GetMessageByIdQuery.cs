using Management.Application.Models.Messages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Queries.Messages.GetMessage
{
    public class GetMessageByIdQuery : IRequest<MessageModel>
    {
        public int Id { get; set; }
        public GetMessageByIdQuery(int id)
        {
            Id = id;
        }
    }
}
