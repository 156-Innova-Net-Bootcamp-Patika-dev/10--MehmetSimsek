using AutoMapper;
using MediatR;
using Payment.Application.Contracts.Persistance.Repositories.Payments;
using Payment.Application.Models.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Application.Features.Queries.Payments.CreditCards.GetCreditCardList.GetAllCreditCard
{
    public class GetCreditCardListQueryHandler : IRequestHandler<GetCreditCardListQuery, IList<CreditCardModel>>
    {
        private readonly ICreditCardRepository _creditCardRepository;
        private readonly IMapper _mapper;

        public GetCreditCardListQueryHandler(ICreditCardRepository creditCardRepository, IMapper mapper)
        {
            _creditCardRepository = creditCardRepository;
            _mapper = mapper;
        }

        public async Task<IList<CreditCardModel>> Handle(GetCreditCardListQuery request, CancellationToken cancellationToken)
        {
            var cardList = await _creditCardRepository.AsQueryableAsync();
            return _mapper.Map<IList<CreditCardModel>>(cardList);
        }
    }
}
