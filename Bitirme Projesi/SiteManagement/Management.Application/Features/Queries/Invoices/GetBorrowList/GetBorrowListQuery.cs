using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Queries.Invoices.GetBorrowList
{
    public class GetBorrowListQuery : IRequest<double>
    {
        public GetBorrowListQuery(int monthId, int apartmentId)
        {
            MonthId = monthId;
            ApartmentId = apartmentId;
        }
        public int MonthId { get; set; }
        public int ApartmentId { get; set; }

    }
}
