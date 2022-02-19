using AutoMapper;
using Management.Application.Contracts.Persistance.Repositories.Residents;
using Management.Domain.Entities.Residents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Commands.Residents.AddResident
{
    public class AddResidentCommandHandler : IRequestHandler<AddResidentCommand, int>
    {
        private readonly IResidentRepository _residentRepository;
        private readonly IMapper _mapper;

        public AddResidentCommandHandler(IResidentRepository residentRepository, IMapper mapper)
        {
            _residentRepository = residentRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddResidentCommand request, CancellationToken cancellationToken)
        {
            var residentEntity = _mapper.Map<Resident>(request);

            //residentEntity.Password = new Random(8).ToString();

            await _residentRepository.AddAsync(residentEntity);

            return residentEntity.Id;
        }
    }
}
