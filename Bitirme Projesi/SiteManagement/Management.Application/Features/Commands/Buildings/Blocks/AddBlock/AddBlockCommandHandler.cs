using AutoMapper;
using Management.Application.Contracts.Persistance.Repositories.Buildings;
using Management.Domain.Entities.Buildings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Commands.Buildings.Blocks.AddBlock
{
    public class AddBlockCommandHandler : IRequestHandler<AddBlockCommand, int>
    {
        private IBlockRepository _blockRepository;
        private IMapper _mapper;

        public AddBlockCommandHandler(IBlockRepository blockRepository, IMapper mapper)
        {
            _blockRepository = blockRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddBlockCommand request, CancellationToken cancellationToken)
        {
            var blockToAdd = _mapper.Map<Block>(request);
            await _blockRepository.AddAsync(blockToAdd);
            return blockToAdd.Id;

        }
    }
}
