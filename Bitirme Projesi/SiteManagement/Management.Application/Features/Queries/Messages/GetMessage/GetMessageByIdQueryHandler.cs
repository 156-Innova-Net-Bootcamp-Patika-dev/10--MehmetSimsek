using AutoMapper;
using Management.Application.Contracts.Persistance.Repositories.Messages;
using Management.Application.Models.Messages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Queries.Messages.GetMessage
{
    public class GetMessageByIdQueryHandler : IRequestHandler<GetMessageByIdQuery, MessageModel>
    {
        private readonly IMessageRepository _mesasgeRepository;
        private readonly IMapper _mapper;

        public GetMessageByIdQueryHandler(IMessageRepository mesasgeRepository, IMapper mapper)
        {
            _mesasgeRepository = mesasgeRepository;
            _mapper = mapper;
        }

        public async Task<MessageModel> Handle(GetMessageByIdQuery request, CancellationToken cancellationToken)
        {
            var messageEntity = await _mesasgeRepository.GetByIdAsync(request.Id);

            return _mapper.Map<MessageModel>(messageEntity);
        }
    }
}
