using Management.Application.Models.Invoices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Queries.Invoices.GetPayment.GetPaymentByUserId
{
    public class GetPaymentByUserIdQuery : IRequest<IList<PaymentModel>>
    {
        public GetPaymentByUserIdQuery(int userId)
        {
            UserId = userId;
        }
        public int UserId { get; set; }
    }
}
