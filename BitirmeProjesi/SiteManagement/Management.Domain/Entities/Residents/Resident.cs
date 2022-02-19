using Management.Domain.Entities.Buildings;
using Management.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Entities.Residents
{
    public class Resident : EntityBase
    {

        public string Name { get; set; }
        public string LastName { get; set; }
        public string NationalIdentificationNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string LicansePlate { get; set; }
        public int ResidentTypeEnumId { get; set; }

      
        




    }
}
