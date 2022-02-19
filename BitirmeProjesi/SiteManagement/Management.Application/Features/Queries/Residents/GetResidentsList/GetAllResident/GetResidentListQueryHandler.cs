using AutoMapper;
using Management.Application.Contracts.Persistance.Repositories.Residents;
using Management.Application.Models.Residents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var residentList = await _residentRepository.GetAllAsync();

            return _mapper.Map<IList<ResidentModel>>(residentList);
        }
    }
}
