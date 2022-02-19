using AutoMapper;
using Management.Application.Contracts.Persistance.Repositories.Residents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Commands.Residents.DeleteResident
{
    public class DeleteResidentCommandHandler : IRequestHandler<DeleteResidentCommand>
    {
       private readonly IResidentRepository _residentRepository;
        private readonly IMapper _mapper;

        public DeleteResidentCommandHandler(IResidentRepository residentRepository, IMapper mapper)
        {
            _residentRepository = residentRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteResidentCommand request, CancellationToken cancellationToken)
        {
            // get the resident to delete using Id
            var residentToDelete = await _residentRepository.GetByIdAsync(request.Id);
            if (residentToDelete == null)
                throw new Exception("Resident cannot be found.");

            // Delete
            await _residentRepository.DeleteAsync(residentToDelete);


            //represent void type.
            return Unit.Value;

        }
    }
}
