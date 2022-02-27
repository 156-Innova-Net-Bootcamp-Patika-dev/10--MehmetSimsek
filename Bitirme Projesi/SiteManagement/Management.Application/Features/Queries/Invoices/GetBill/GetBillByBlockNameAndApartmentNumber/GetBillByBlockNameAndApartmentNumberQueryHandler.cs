using AutoMapper;
using Management.Application.Contracts.Persistance.Repositories.Buildings;
using Management.Application.Contracts.Persistance.Repositories.Invoices;
using Management.Application.Models.Invoices;
using Management.Domain.Entities.Buildings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Queries.Invoices.GetBill.GetBillByBlockNameAndApartmentNumber
{
    public class GetBillByBlockNameAndApartmentNumberQueryHandler : IRequestHandler<GetBillByBlockNameAndApartmentNumberQuery, IList<BillModel>>
    {
        private readonly IBillRepository _billRepository;
        private readonly IMapper _mapper;
        private readonly IApartmentRepository _apartmentRepository;


        public GetBillByBlockNameAndApartmentNumberQueryHandler(IBillRepository billRepository, IMapper mapper, IApartmentRepository apartmentRepository)
        {
            _billRepository = billRepository;
            _mapper = mapper;
            _apartmentRepository = apartmentRepository;
        }

        public async Task<IList<BillModel>> Handle(GetBillByBlockNameAndApartmentNumberQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Apartment, object>> includeBlock = p => p.Block;
            List<Expression<Func<Apartment, object>>> includes = new List<Expression<Func<Apartment, object>>> { includeBlock};
            
            var apartmentsInBlock = await _apartmentRepository.GetAsync(a=>a.Id>0, null, includes );
            foreach (var apartment in apartmentsInBlock)
            {
                if (apartment.Block.Name == request.BlockName)
                {
                    if (apartment.ApartmentNumber != request.ApartmentNumber)
                        request.Bills = apartment.Bill;
                }
                
            }
            return _mapper.Map<IList<BillModel>>(request.Bills);
        }
    }
}
