using AutoMapper;
using Management.Application.Contracts.Persistance.Repositories.Residents;
using Management.Application.Models.Residents;
using Management.Domain.Entities.Residents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Queries.Residents.GetResidentsList.GetAllResident
{
    public class GetResidentListQueryHandler : IRequestHandler<GetResidentListQuery, IList<ResidentModel>>
    {
        IResidentRepository _residentRepository;
        IMapper _mapper;

        public GetResidentListQueryHandler(IResidentRepository residentRepository, IMapper mapper)
        {
            _residentRepository = residentRepository;
            _mapper = mapper;
        }

        public async Task<IList<ResidentModel>> Handle(GetResidentListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Resident, object>> includeApartment = r=> r.Apartment;
            Expression<Func<Resident, object>> includeUser = p => p.User;
            List<Expression<Func<Resident, object>>> includes = new List<Expression<Func<Resident, object>>> { includeApartment, includeUser };

            var residentList = await _residentRepository.GetAsync(p => p.Id > 0, null, includes);

            return _mapper.Map<IList<ResidentModel>>(residentList);
        }
    }
}
