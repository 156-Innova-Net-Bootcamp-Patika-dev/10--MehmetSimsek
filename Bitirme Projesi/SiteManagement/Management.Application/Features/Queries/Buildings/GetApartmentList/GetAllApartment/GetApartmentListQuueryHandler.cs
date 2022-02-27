using AutoMapper;
using Management.Application.Contracts.Persistance.Repositories.Buildings;
using Management.Application.Models.Buildings;
using Management.Domain.Entities.Buildings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Queries.Buildings.GetApartmentList.GetAllApartment
{
    public class GetApartmentListQuueryHandler : IRequestHandler<GetApartmentListQuery, IList<ApartmentModel>>
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;

        public GetApartmentListQuueryHandler(IMapper mapper, IApartmentRepository apartmentRepository)
        {
            _mapper = mapper;
            _apartmentRepository = apartmentRepository;
        }

        public async Task<IList<ApartmentModel>> Handle(GetApartmentListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Apartment, object>> includeBlocks = p => p.Block;
            Expression<Func<Apartment, object>> includeApartments = p => p.ApartmentType;
            List<Expression<Func<Apartment, object>>> includes = new List<Expression<Func<Apartment, object>>>{ includeApartments, includeBlocks };

            var apartmentList = await _apartmentRepository.GetAsync(p => p.Id > 0, null, includes);

            return _mapper.Map<IList<ApartmentModel>>(apartmentList);

        }
    }
}
