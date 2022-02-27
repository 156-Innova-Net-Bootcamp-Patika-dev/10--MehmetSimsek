using AutoMapper;
using Management.Application.Contracts.Persistance.Repositories.Invoices;
using Management.Application.Models.Invoices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Queries.Invoices.GetPayment.GetPaymentByUserId
{
    public class GetPaymentByUserIdQueryHandler : IRequestHandler<GetPaymentByUserIdQuery, IList<PaymentModel>>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public GetPaymentByUserIdQueryHandler(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<IList<PaymentModel>> Handle(GetPaymentByUserIdQuery request, CancellationToken cancellationToken)
        {
            var payments = await _paymentRepository.GetAsync(p => p.UserId == request.UserId);
            return _mapper.Map<IList<PaymentModel>>(payments);
        }
    }
}
