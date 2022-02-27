using Management.Application.Contracts.Persistance.Repositories.Invoices;
using Management.Domain.Entites.Invoices;
using Management.Infrastructure.Contracts.Persistance.Repositories.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Infrastructure.Contracts.Persistance.Repositories.Invoices
{
    public class BillRepository : RepositoryBase<Bill>, IBillRepository
    {
        public BillRepository(ApplicationContext context) : base(context)
        {
            
        }

      
    }
}
