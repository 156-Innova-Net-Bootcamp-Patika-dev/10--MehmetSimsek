using AutoMapper;
using MediatR;
using MongoDB.Bson;
using Payment.Application.Contracts.Persistance.Repositories.Payments;
using Payment.Domain.Entities.CreditCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Application.Features.Commands.Payments.CreditCards.AddCreditCard
{
    public class AddCreditCardCommandHandler : IRequestHandler<AddCreditCardCommand, ObjectId>
    {
        private readonly ICreditCardRepository _creditCardRepository;
        private readonly IMapper _mapper;

        public AddCreditCardCommandHandler(ICreditCardRepository creditCardRepository, IMapper mapper)
        {
            _creditCardRepository = creditCardRepository;
            _mapper = mapper;
        }

        public async Task<ObjectId> Handle(AddCreditCardCommand request, CancellationToken cancellationToken)
        {
            var creditCard = _mapper.Map<CreditCard>(request);
            await _creditCardRepository.InsertOneAsync(creditCard);
            return request.Id;
        }
    }
}
