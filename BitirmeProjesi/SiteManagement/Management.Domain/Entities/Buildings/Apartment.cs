using Management.Domain.Entities.Commons;
using Management.Domain.Entities.Residents;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Entities.Buildings
{
    public class Apartment : EntityBase
    {
        [ForeignKey(nameof(Block))]
        public int BlockId { get; set; }
        public byte HasResident { get; set; }
       [ForeignKey(nameof(ApartmentType))]
        public int ApartmentTypeId { get; set; }
        public int FloorNumber { get; set; }
        public int ApartmentNumber { get; set; }




       public Block Block { get; set; }
       public ApartmentType ApartmentType { get; set; }

    }
}
