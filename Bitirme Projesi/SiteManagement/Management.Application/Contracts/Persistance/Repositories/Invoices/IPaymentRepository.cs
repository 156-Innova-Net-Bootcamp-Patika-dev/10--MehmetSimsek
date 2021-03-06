using Management.Application.Contracts.Persistance.Repositories.Commons;
using Management.Domain.Entities.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Contracts.Persistance.Repositories.Invoices
{
    public interface IPaymentRepository : IRepositoryBase<Payment>
    {
    }
}
