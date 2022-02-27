using Management.Application.Models.Invoices;
using Management.Domain.Entites.Invoices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Queries.Invoices.GetBill.GetBillByBlockNameAndApartmentNumber
{
    public class GetBillByBlockNameAndApartmentNumberQuery : IRequest<IList<BillModel>>
    {
        public GetBillByBlockNameAndApartmentNumberQuery(string blockName, int apartmentNumber)
        {
            BlockName = blockName;
            ApartmentNumber = apartmentNumber;
        }
        public string BlockName { get; set; }
        public int ApartmentNumber { get; set; }
        public ICollection<Bill> Bills { get; set; }
    }
}
