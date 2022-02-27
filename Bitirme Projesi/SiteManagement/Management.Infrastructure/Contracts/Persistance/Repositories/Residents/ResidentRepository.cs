using Management.Application.Contracts.Persistance.Repositories.Residents;
using Management.Domain.Entities.Residents;
using Management.Infrastructure.Contracts.Persistance.Repositories.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Infrastructure.Contracts.Persistance.Repositories.Residents
{
    public class ResidentRepository : RepositoryBase<Resident>, IResidentRepository
    {

        public ResidentRepository(ApplicationContext dbContext) : base(dbContext)
        {

        }
    }
}
