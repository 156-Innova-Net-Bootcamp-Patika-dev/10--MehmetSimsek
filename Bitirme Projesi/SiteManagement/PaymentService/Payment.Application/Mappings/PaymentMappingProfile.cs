using AutoMapper;
using Payment.Application.Features.Commands.Payments.CreditCards.AddCreditCard;
using Payment.Application.Models.Payments;
using Payment.Domain.Entities.CreditCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Application.Mappings
{
    public class PaymentMappingProfile : Profile
    {
        public PaymentMappingProfile()
        {
            //Credit Card Mapping Process
            CreateMap<CreditCard, AddCreditCardCommand>().ReverseMap();
            CreateMap<CreditCard, CreditCardModel>().ReverseMap();

            


        }
    }
}
