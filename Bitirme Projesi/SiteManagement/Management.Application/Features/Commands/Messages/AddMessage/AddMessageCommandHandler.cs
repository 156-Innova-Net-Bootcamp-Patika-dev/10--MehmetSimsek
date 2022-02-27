using AutoMapper;
using Management.Application.Contracts.Persistance.Repositories.Messages;
using Management.Domain.Entites.Messages;
using Management.Domain.Enums.Messages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Commands.Messages.AddMessage
{
    public class AddMessageCommandHandler : IRequestHandler<AddMessageCommand, int>
    {
       private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public AddMessageCommandHandler(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddMessageCommand request, CancellationToken cancellationToken)
        {
           var messageToAdd = _mapper.Map<Message>(request);
            messageToAdd.MessageSeenInfoEnumId = (int)MessageSeenInfoEnum.Forwerded;
            await _messageRepository.AddAsync(messageToAdd);
            return messageToAdd.Id;
        }
    }
}
