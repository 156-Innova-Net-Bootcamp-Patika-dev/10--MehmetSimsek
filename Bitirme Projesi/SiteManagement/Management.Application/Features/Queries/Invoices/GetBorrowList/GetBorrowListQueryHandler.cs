using AutoMapper;
using Management.Application.Contracts.Persistance.Repositories.Invoices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Queries.Invoices.GetBorrowList
{
    public class GetBorrowListQueryHandler : IRequestHandler<GetBorrowListQuery, double>
    {
        private readonly IBillRepository _billRepository;
        private readonly IMapper _mapper;

        public GetBorrowListQueryHandler(IBillRepository billRepository, IMapper mapper)
        {
            _billRepository = billRepository;
            _mapper = mapper;
        }

        public async Task<double> Handle(GetBorrowListQuery request, CancellationToken cancellationToken)
        {

            var total = 0.0;
            var queries = await _billRepository.GetAsync(b=>b.MonthOfBill == request.MonthId);

           
            
            foreach (var query in queries)
            {
                if (query.ApartmentId == request.ApartmentId)
                {
                    if (!query.IsPaid)
                        total += query.BillAmount;
                }

            }
            
            return total;
        }
    }
}
