using Management.Domain.Entites.Messages;
using Management.Domain.Entities.Authentications;
using Management.Domain.Entities.Buildings;
using Management.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Entities.Residents
{
    public class Resident : EntityBase
    {
       [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        [ForeignKey(nameof(Apartment))]
        public int ApartmentId { get; set; }
        public string NationalIdentificationNo { get; set; }
        public string PhoneNumber { get; set; }
        public string LicansePlate { get; set; }
        public int ResidentTypeEnumId { get; set; }
        
        public Apartment Apartment { get; set; }
        public User User { get; set; }







    }
}
