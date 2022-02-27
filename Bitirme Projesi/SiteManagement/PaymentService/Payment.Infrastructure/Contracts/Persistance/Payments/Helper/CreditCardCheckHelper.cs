using Payment.Application.Contracts.Persistance.Repositories.Payments;
using Payment.Application.Contracts.Persistance.Repositories.Payments.Helper;
using Payment.Domain.Entities.CreditCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.Contracts.Persistance.Payments.Helper
{
    public class CreditCardCheckHelper : ICreditCardCheckHelper
    {
        ICreditCardRepository _creditCardRepository;
        public CreditCardCheckHelper(ICreditCardRepository creditCardRepository)
        {
            _creditCardRepository = creditCardRepository;
        }
        public async Task CheckCardForPayment(CreditCard creditCard)
        {
            var cardToCheck = await _creditCardRepository.GetByFilterAsync(c => c.UserId == creditCard.UserId);
            if ((cardToCheck.CardNumber != creditCard.CardNumber)
                && (cardToCheck.CardPassword == creditCard.CardPassword)
                && (cardToCheck.Balance < creditCard.Balance))
            { creditCard.Balance -= creditCard.Balance; }
            await _creditCardRepository.ReplaceOneAsync(cardToCheck, creditCard.Id.ToString());








        }
    }
}
