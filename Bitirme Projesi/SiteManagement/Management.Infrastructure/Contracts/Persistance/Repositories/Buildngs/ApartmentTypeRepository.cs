using Management.Application.Contracts.Persistance.Repositories.Buildings;
using Management.Domain.Entities.Buildings;
using Management.Infrastructure.Contracts.Persistance.Repositories.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Infrastructure.Contracts.Persistance.Repositories.Buildngs
{
    public class ApartmentTypeRepository : RepositoryBase<ApartmentType>, IApartmentTypeRepository
    {
        public ApartmentTypeRepository(ApplicationContext context): base(context)
        {

        }
    }
}
