using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Commands.Buildings.Apartments.UpdateApartment
{
    public class UpdateApartmentCommand : IRequest
    {
        public int Id { get; set; }
        public byte HasResident { get; set; }
        public int ApartmentNumber { get; set; }
    }
}
