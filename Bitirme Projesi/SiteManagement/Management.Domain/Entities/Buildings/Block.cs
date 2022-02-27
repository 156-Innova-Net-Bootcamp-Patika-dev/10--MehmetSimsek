using Management.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Entities.Buildings
{
    public class Block : EntityBase
    {
        public Block()
        {
            Apartments = new HashSet<Apartment>();
        }
        public string Name { get; set; }

        public ICollection<Apartment> Apartments { get; set; }
    }
}
