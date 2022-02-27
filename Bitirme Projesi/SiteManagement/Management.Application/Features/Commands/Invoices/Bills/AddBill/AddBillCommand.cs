using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Commands.Invoices.Bills.AddBill
{
    public class AddBillCommand : IRequest<int>
    {
        public int BillTypeEnumId { get; set; }
        public int MonthOfBill { get; set; }
        public double BillAmount { get; set; }
        public int ApartmentId { get; set; }
    }
}
