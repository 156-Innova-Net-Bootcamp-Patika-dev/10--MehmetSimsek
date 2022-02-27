using MediatR;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Application.Features.Commands.Payments.CreditCards.AddCreditCard
{
    public class AddCreditCardCommand : IRequest<ObjectId>
    {
        public ObjectId Id { get; set; }
        public int UserId { get; set; }
        public string CardNumber { get; set; }
        public string CardPassword { get; set; }
        public double Balance { get; set; }
    }
}
