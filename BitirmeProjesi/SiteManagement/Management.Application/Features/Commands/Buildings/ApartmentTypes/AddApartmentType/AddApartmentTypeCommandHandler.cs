using AutoMapper;
using Management.Application.Contracts.Persistance.Repositories.Buildings;
using Management.Domain.Entities.Buildings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Commands.Buildings.ApartmentTypes.AddApartmentType
{
    public class AddApartmentTypeCommandHandler : IRequestHandler<AddApartmentTypeCommand, int>
    {
        private readonly IApartmentTypeRepository _apartmenTypeRepository;
        private readonly IMapper _mapper;

        public AddApartmentTypeCommandHandler(IApartmentTypeRepository apartmenTypeRepository, IMapper mapper)
        {
            _apartmenTypeRepository = apartmenTypeRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddApartmentTypeCommand request, CancellationToken cancellationToken)
        {
            var apartmentTypeToAdd = _mapper.Map<ApartmentType>(request);
            await _apartmenTypeRepository.AddAsync(apartmentTypeToAdd);
            return apartmentTypeToAdd.Id;
        }
    }
}
