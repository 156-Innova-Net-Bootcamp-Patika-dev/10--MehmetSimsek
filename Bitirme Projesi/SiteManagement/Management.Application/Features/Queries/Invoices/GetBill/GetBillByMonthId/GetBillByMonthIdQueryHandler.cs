using AutoMapper;
using Management.Application.Contracts.Persistance.Repositories.Invoices;
using Management.Application.Models.Invoices;
using Management.Domain.Entites.Invoices;
using Management.Domain.Enums.Invoices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Queries.Invoices.GetBill.GetBillByMonthId
{
    public class GetBillByMonthIdQueryHandler : IRequestHandler<GetBillByMonthIdQuery, BillModel>
    {
        private readonly IBillRepository _billRepository;
        private readonly IMapper _mapper;


        public GetBillByMonthIdQueryHandler(IBillRepository billRepository, IMapper mapper)
        {
            _billRepository = billRepository;
            _mapper = mapper;
        }

        public async Task<BillModel> Handle(GetBillByMonthIdQuery request, CancellationToken cancellationToken)
        {
          
            var query = await _billRepository.GetAsync(b => b.MonthOfBill == request.MonthOfBill);
            
            return _mapper.Map<BillModel>(query);
        }
    }
}
