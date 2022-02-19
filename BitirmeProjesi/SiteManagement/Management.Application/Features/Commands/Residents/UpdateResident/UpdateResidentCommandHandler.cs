using AutoMapper;
using Management.Application.Contracts.Persistance.Repositories.Residents;
using Management.Domain.Entities.Residents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Commands.Residents.UpdateResident
{
    public class UpdateResidentCommandHandler : IRequestHandler<UpdateResidentCommand>
    {
        private readonly IResidentRepository _residentRepository;
        private readonly IMapper _mapper;

        public UpdateResidentCommandHandler(IResidentRepository residentRepository, IMapper mapper)
        {
            _residentRepository = residentRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateResidentCommand request, CancellationToken cancellationToken)
        {
            var residentToUpdate =  await _residentRepository.GetByIdAsync(request.Id);
            if (residentToUpdate == null)
                throw new Exception("Resident cannot be found");

            _mapper.Map(request,residentToUpdate, typeof(UpdateResidentCommand), typeof(Resident));

            await _residentRepository.UpdateAsync(residentToUpdate);

            return Unit.Value;
            

            

        }
    }
}
