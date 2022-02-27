using Management.Application.Models.Buildings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Queries.Buildings.GetApartmentTypeList.GetAllApartmentType
{
    public class GetApartmentTypeListQuery: IRequest<IList<ApartmentTypeModel>>
    {
        public GetApartmentTypeListQuery()
        {

        }
    }
}
