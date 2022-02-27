using AutoMapper;
using Management.Application.Contracts.Persistance.Repositories.Messages;
using Management.Application.Models.Messages;
using Management.Domain.Entites.Messages;
using Management.Domain.Enums.Messages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Queries.Messages.GetAllMessage
{
    internal class GetMessageListQueryHandler : IRequestHandler<GetMessageListQuery, IList<MessageModel>>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public GetMessageListQueryHandler(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<IList<MessageModel>> Handle(GetMessageListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Message, object>> includeReciever = p => p.MessageReciever;
            Expression<Func<Message, object>> includeSender = p => p.MessageSender;
            List<Expression<Func<Message, object>>> includes = new List<Expression<Func<Message, object>>> { includeReciever, includeSender };


            var messageList = await _messageRepository.GetAsync(p=>p.Id>0 , null, includes);
             messageList.ToList().ForEach(message => message.MessageSeenInfoEnumId = (int)MessageSeenInfoEnum.Seen);
           
            return _mapper.Map<IList<MessageModel>>(messageList);
           
            
        }
    }
}
