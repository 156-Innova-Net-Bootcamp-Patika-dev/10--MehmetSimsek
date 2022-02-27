using Management.Application.Models.Buildings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Queries.Buildings.GetBlockList.GetAllBlock
{
    public class GetBlockListQuery : IRequest<IList<BlockModel>>
    {
        public GetBlockListQuery()
        {

        }
    }
}
