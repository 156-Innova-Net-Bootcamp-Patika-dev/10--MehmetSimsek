using AutoMapper;
using Management.Application.Contracts.Persistance.Repositories.Buildings;
using Management.Domain.Entities.Buildings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Commands.Buildings.Apartments.UpdateApartment
{
    public class UpdateApartmentCommandHandler : IRequestHandler<UpdateApartmentCommand>
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;

        public UpdateApartmentCommandHandler(IApartmentRepository apartmentRepository, IMapper mapper)
        {
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateApartmentCommand request, CancellationToken cancellationToken)
        {
            var apartmentToUpdate = await _apartmentRepository.GetByIdAsync(request.Id);
            if (apartmentToUpdate == null)
                throw new Exception("Apartment cannot be found!");

            _mapper.Map(request,apartmentToUpdate,typeof(UpdateApartmentCommand),typeof(Apartment));
            await _apartmentRepository.UpdateAsync(apartmentToUpdate);
            return Unit.Value;
        }
    }
}
