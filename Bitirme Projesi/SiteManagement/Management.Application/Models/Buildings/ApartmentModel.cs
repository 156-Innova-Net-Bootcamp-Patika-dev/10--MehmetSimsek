using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Models.Buildings
{
    public class ApartmentModel
    {
        public int Id { get; set; }
        public string BlockName { get; set; }
        public string ApartmentTypeName { get; set; }
        public int FloorNumber { get; set; }
        public int ApartmentNumber { get; set; }

    }
}
