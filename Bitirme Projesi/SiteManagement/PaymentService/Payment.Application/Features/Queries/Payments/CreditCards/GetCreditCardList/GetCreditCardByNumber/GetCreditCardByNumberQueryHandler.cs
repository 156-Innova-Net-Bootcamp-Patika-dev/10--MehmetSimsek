using AutoMapper;
using MediatR;
using Payment.Application.Contracts.Persistance.Repositories.Payments;
using Payment.Application.Models.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Application.Features.Queries.Payments.CreditCards.GetCreditCardList.GetCreditCardByNumber
{
    public class GetCreditCardByNumberQueryHandler : IRequestHandler<GetCreditCardByNumberQuery, CreditCardModel>
    {
        private readonly ICreditCardRepository _creditCardRepository;
        private readonly IMapper _mapper;

        public GetCreditCardByNumberQueryHandler(ICreditCardRepository creditCardRepository, IMapper mapper)
        {
            _creditCardRepository = creditCardRepository;
            _mapper = mapper;
        }

        public async Task<CreditCardModel> Handle(GetCreditCardByNumberQuery request, CancellationToken cancellationToken)
        {
            var query = await _creditCardRepository.GetByFilterAsync(c=>c.CardNumber == request.CardNumber);
            return _mapper.Map<CreditCardModel>(query);
        }
    }
}
