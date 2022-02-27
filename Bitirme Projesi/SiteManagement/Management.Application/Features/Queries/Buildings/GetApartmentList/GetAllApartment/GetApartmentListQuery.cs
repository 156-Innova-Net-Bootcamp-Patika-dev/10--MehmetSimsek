using Management.Application.Models.Buildings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Queries.Buildings.GetApartmentList.GetAllApartment
{
    public class GetApartmentListQuery : IRequest<IList<ApartmentModel>>
    {
        public GetApartmentListQuery()
        {

        }
        public int ApartmentTypeId { get; set; }
        public int BlockId { get; set; }

    }
}
