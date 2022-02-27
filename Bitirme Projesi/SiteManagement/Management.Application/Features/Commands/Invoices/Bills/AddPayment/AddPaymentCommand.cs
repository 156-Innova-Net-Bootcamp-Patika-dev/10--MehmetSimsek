using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Commands.Invoices.Bills.AddPayment
{
    public class AddPaymentCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public int BillId { get; set; }
        public string CardNumber { get; set; }
        public string CardPassword { get; set; }
        public double Amount { get; set; }
    }
}
