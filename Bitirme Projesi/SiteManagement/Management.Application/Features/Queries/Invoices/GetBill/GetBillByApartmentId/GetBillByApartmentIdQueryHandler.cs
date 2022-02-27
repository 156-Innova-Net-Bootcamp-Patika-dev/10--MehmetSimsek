using AutoMapper;
using Management.Application.Contracts.Persistance.Repositories.Buildings;
using Management.Application.Contracts.Persistance.Repositories.Invoices;
using Management.Application.Models.Invoices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Queries.Invoices.GetBill.GetBillByApartmentId
{
    public class GetBillByApartmentIdQueryHandler : IRequestHandler<GetBillByApartmentIdQuery, IList<BillModel>>
    {
        private readonly IBillRepository _billRepository;
        private readonly IMapper _mapper;
      

        public GetBillByApartmentIdQueryHandler(IBillRepository billRepository, IMapper mapper)
        {
            _billRepository = billRepository;
            _mapper = mapper;
           
        }

        public async Task<IList<BillModel>> Handle(GetBillByApartmentIdQuery request, CancellationToken cancellationToken)
        {
            var bills = await _billRepository.GetAsync(b=>b.ApartmentId == request.ApartmentId);
            return _mapper.Map<IList<BillModel>>(bills);

        }

        
    }
}
