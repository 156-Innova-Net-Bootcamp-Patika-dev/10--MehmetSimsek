using MediatR;
using Payment.Application.Models.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Application.Features.Queries.Payments.CreditCards.GetCreditCardList.GetCreditCardByNumber
{
    public class GetCreditCardByNumberQuery : IRequest<CreditCardModel>
    {
        public GetCreditCardByNumberQuery(string cardNumber)
        {
            CardNumber = cardNumber;
        }
        public string CardNumber { get; set; }
    }
}
