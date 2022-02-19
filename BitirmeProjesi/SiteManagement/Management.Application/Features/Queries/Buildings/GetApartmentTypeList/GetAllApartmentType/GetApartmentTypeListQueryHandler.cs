using AutoMapper;
using Management.Application.Contracts.Persistance.Repositories.Buildings;
using Management.Application.Models.Buildings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Queries.Buildings.GetApartmentTypeList.GetAllApartmentType
{
    public class GetApartmentTypeListQueryHandler : IRequestHandler<GetApartmentTypeListQuery, IList<ApartmentTypeModel>>
    {
        private readonly IApartmentTypeRepository _apartmentTypeRepository;
        private readonly IMapper _mapper;

        public GetApartmentTypeListQueryHandler(IApartmentTypeRepository apartmentTypeRepository, IMapper mapper)
        {
            _apartmentTypeRepository = apartmentTypeRepository;
            _mapper = mapper;
        }

        public async Task<IList<ApartmentTypeModel>> Handle(GetApartmentTypeListQuery request, CancellationToken cancellationToken)
        {
            var apartmentTypeList = await _apartmentTypeRepository.GetAllAsync();
            return _mapper.Map<IList<ApartmentTypeModel>>(apartmentTypeList);
        }
    }
}
