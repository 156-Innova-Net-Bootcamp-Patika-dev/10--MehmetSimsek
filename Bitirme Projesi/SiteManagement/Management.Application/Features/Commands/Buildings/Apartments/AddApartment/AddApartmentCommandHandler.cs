using AutoMapper;
using Management.Application.Contracts.Persistance.Repositories.Buildings;
using Management.Domain.Entities.Buildings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Commands.Buildings.Apartments.AddApartment
{
    public class AddApartmentCommandHandler : IRequestHandler<AddApartmentCommand, int>
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;

        public AddApartmentCommandHandler(IApartmentRepository apartmentRepository, IMapper mapper)
        {
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddApartmentCommand request, CancellationToken cancellationToken)
        {
            var apartmentToAdd = _mapper.Map<Apartment>(request);
            await _apartmentRepository.AddAsync(apartmentToAdd);
            return apartmentToAdd.Id;
        }
    }
}
