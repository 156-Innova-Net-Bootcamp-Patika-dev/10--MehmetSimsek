using Management.Application.Contracts.Persistance.Repositories.Commons;
using Management.Domain.Entities.Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Contracts.Persistance.Repositories.Buildings
{
    public interface IApartmentRepository : IRepositoryBase<Apartment>
    {
    }
}
