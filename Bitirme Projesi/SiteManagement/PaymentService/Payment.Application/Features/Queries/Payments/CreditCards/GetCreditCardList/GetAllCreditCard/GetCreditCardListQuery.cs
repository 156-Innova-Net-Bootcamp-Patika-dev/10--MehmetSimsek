using MediatR;
using Payment.Application.Models.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Application.Features.Queries.Payments.CreditCards.GetCreditCardList.GetAllCreditCard
{
    public class GetCreditCardListQuery : IRequest<IList<CreditCardModel>>
    {
     
    }
}
