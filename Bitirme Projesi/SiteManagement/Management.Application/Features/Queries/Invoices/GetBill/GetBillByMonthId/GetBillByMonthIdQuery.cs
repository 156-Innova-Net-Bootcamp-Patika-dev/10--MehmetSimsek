using Management.Application.Models.Invoices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Queries.Invoices.GetBill.GetBillByMonthId
{
    public class GetBillByMonthIdQuery : IRequest<BillModel>
    {
        public int MonthOfBill { get; set; }

    }
}
