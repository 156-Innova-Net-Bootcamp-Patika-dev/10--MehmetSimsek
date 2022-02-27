using Management.Application.Models.Invoices;
using Management.Domain.Entites.Invoices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Queries.Invoices.GetBill.GetBillByApartmentId
{
    public class GetBillByApartmentIdQuery : IRequest<IList<BillModel>>
    {
        public GetBillByApartmentIdQuery(int apartmentId)
        {
           ApartmentId = apartmentId;
        }
        
        public int ApartmentId { get; set; }
        
    }
}
