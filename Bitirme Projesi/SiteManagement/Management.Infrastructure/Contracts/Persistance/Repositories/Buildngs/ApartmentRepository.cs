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
    public class ApartmentRepository: RepositoryBase<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(ApplicationContext context) : base(context)
        {
            
        }
    }
}
