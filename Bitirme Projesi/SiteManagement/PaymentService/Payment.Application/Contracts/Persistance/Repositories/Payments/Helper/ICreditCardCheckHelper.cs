using Payment.Domain.Entities.CreditCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Application.Contracts.Persistance.Repositories.Payments.Helper
{
    public interface ICreditCardCheckHelper
    {
         Task CheckCardForPayment(CreditCard creditCard);
    }
}
