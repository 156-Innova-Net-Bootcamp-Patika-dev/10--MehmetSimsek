using AutoMapper;
using Management.Application.Contracts.Persistance.Repositories.Buildings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Commands.Buildings.Apartments.DeleteApartment
{
    public class DeleteApartmentCommandHandler : IRequestHandler<DeleteApartmentCommand>
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;

        public DeleteApartmentCommandHandler(IApartmentRepository apartmentRepository, IMapper mapper)
        {
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteApartmentCommand request, CancellationToken cancellationToken)
        {
            var apartmentToDelete = await _apartmentRepository.GetByIdAsync(request.Id);
            if (apartmentToDelete == null)
                throw new Exception("Apartment cannot be found!");

            
            await _apartmentRepository.DeleteAsync(apartmentToDelete);
            return Unit.Value;
        }
    }
}
