using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Commands.Residents.AddResident
{
    public class AddResidentCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public int ApartmentId { get; set; }
        public string NationalIdentificationNo { get; set; }
        public string PhoneNumber { get; set; }
        public string LicansePlate { get; set; }


    }
}
