using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Commands.Residents.UpdateResident
{
    public class UpdateResidentCommand: IRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ApartmentId { get; set; }
        public string NationalIdentificationNo { get; set; }
        public string PhoneNumber { get; set; }
        public string LicansePlate { get; set; }

    }
}
