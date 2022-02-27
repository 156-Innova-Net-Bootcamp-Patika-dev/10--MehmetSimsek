using Management.Application.Models.Invoices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Queries.Invoices.GetBillList.GetAllBill
{
    public class GetBillListQuery : IRequest<IList<BillModel>>
    {
        public GetBillListQuery()
        {

        }
        public int MonthOfBill { get; set; }
        public int TypeOfBill { get; set; }
        public int ApartmentId { get; set; }

    }
}
