using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Models.Residents
{
    public class ResidentModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int ApartmentNumber { get; set; }
        public int FloorNumber { get; set; }
        public string NationalIdentificationNo { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
}
