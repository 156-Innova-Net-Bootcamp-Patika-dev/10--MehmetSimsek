using Management.Application.Models.Messages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Queries.Messages.GetAllMessage
{
    public class GetMessageListQuery : IRequest<IList<MessageModel>>
    {
        public GetMessageListQuery()
        {

        }
        public int RecieverId { get; set; }
        public int SenderId { get; set; }

    }
}
