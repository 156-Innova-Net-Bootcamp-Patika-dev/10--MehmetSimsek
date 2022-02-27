using AutoMapper;
using Management.Application.Contracts.Persistance.Repositories.Invoices;
using Management.Domain.Entites.Invoices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Commands.Invoices.Bills.AddBill
{
    public class AddBillCommandHandler : IRequestHandler<AddBillCommand, int>
    {
        private readonly IBillRepository _billRepository;
        private readonly IMapper _mapper;

        public AddBillCommandHandler(IBillRepository billRepository, IMapper mapper)
        {
            _billRepository = billRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddBillCommand request, CancellationToken cancellationToken)
        {
            var billToAdd = _mapper.Map<Bill>(request);
            billToAdd.CreatedDate = DateTime.Now;
            billToAdd.IsPaid = false;
            await _billRepository.AddAsync(billToAdd);
            return billToAdd.Id;
        }
     


    }
}
