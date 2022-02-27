using Management.Application.Contracts.Persistance.Repositories.Commons;
using Management.Domain.Entities.Residents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Contracts.Persistance.Repositories.Residents
{
    public interface IResidentRepository : IRepositoryBase<Resident>
    {
    }
}
