using Management.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Entities.Buildings
{
    public class ApartmentType : EntityBase
    {
        public ApartmentType()
        {
            Apartments = new HashSet<Apartment>();
        }
        public string Name { get; set; }
        
        public ICollection<Apartment> Apartments { get; set; }
    }
}
