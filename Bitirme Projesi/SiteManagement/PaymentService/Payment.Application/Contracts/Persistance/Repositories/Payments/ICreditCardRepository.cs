using Payment.Application.Contracts.Persistance.Repositories.Commons;
using Payment.Domain.Entities.CreditCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Application.Contracts.Persistance.Repositories.Payments
{
    public interface ICreditCardRepository : IMongoRepositoryBase<CreditCard>
    {
        Task<CreditCard> GetCreditCardByCardNumber(string cardNumber);
    }
}
