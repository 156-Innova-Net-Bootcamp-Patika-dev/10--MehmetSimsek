using Management.Application.Models.Residents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Queries.Residents.GetResidentsList.GetAllResident
{
    public class GetResidentListQuery : IRequest<IList<ResidentModel>>
    {
        public GetResidentListQuery()
        {

        }
    }
}
