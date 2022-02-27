using AutoMapper;
using Management.Application.Contracts.Persistance.Repositories.Invoices;
using Management.Application.Models.Invoices;
using Management.Domain.Entites.Invoices;
using Management.Domain.Enums.Invoicecs;
using Management.Domain.Enums.Invoices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Queries.Invoices.GetBillList.GetAllBill
{
    public class GetBillListQueryHandler : IRequestHandler<GetBillListQuery, IList<BillModel>>
    {
        private readonly IBillRepository _billRepository;
        private readonly IMapper _mapper;


        public GetBillListQueryHandler(IBillRepository billRepository, IMapper mapper)
        {
            _billRepository = billRepository;
            _mapper = mapper;
        }

        public async Task<IList<BillModel>> Handle(GetBillListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Bill, object>> includeApartments = p => p.Apartment;
            List<Expression<Func<Bill, object>>> includes = new List<Expression<Func<Bill, object>>> { includeApartments };


            var billList = await _billRepository.GetAsync(p=>p.Id>0 , null, includes);
            
            return _mapper.Map<IList<BillModel>>(billList);

        }
    }
}
