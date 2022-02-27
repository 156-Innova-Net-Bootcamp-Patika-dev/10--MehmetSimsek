using AutoMapper;
using Management.Application.Contracts.Persistance.Repositories.Buildings;
using Management.Application.Models.Buildings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Queries.Buildings.GetBlockList.GetAllBlock
{
    public class GetBlockListQueryHandler : IRequestHandler<GetBlockListQuery, IList<BlockModel>>
    {
        private readonly IBlockRepository _blockRepository;
        private readonly IMapper _mapper;

        public GetBlockListQueryHandler(IBlockRepository blockRepository, IMapper mapper)
        {
            _blockRepository = blockRepository;
            _mapper = mapper;
        }

        public async Task<IList<BlockModel>> Handle(GetBlockListQuery request, CancellationToken cancellationToken)
        {
            var blockList = await _blockRepository.GetAllAsync();
            return _mapper.Map<IList<BlockModel>>(blockList);
        }
    }
}
