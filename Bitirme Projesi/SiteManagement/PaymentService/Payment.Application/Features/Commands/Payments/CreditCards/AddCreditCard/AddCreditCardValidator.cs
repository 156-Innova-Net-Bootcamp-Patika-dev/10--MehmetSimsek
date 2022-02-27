using FluentValidation;
using Payment.Domain.Entities.CreditCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Application.Features.Commands.Payments.CreditCards.AddCreditCard
{
    public class AddCreditCardValidator : AbstractValidator<CreditCard>
    {
        public AddCreditCardValidator()
        {

        }
    }
}
