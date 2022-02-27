using Management.Application.Contracts.Persistance.Repositories.Invoices;
using Management.Domain.Entities.Invoices;
using Management.Infrastructure.Contracts.Persistance.Repositories.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Infrastructure.Contracts.Persistance.Repositories.Invoices
{
    public class PaymentRepository : RepositoryBase<Payment>, IPaymentRepository
    {
        public PaymentRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
