using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Payment.Application.Contracts.Persistance.Repositories.Payments;
using Payment.Domain.Entities.CreditCards;
using Payment.Infrastructure.Contracts.Persistance.Commons;
using Payment.Infrastructure.Contracts.Persistance.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.Contracts.Persistance.Payments
{
    public class CreditCardRepository : MongoRepositoryBase<CreditCard>, ICreditCardRepository
    {
        private readonly PaymentDbContext _paymentDbContext;
        private readonly IMongoCollection<CreditCard> _collection;
        public CreditCardRepository(IOptions<PaymentDbSettings> settings) : base(settings)
        {
            _paymentDbContext = new PaymentDbContext(settings);
            _collection = _paymentDbContext.GetCollection<CreditCard>();
        }

        public async Task<CreditCard> GetCreditCardByCardNumber(string cardNumber)
        {
            var card = await _collection.FindAsync(cardNumber);
            return await card.FirstOrDefaultAsync();
        }
    }
}
