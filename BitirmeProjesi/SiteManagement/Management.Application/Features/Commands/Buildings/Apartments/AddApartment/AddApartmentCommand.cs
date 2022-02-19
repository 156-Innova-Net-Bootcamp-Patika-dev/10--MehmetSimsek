using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Commands.Buildings.Apartments.AddApartment
{
    public class AddApartmentCommand : IRequest<int>
    {

        public int BlockId { get; set; }
        public byte HasResident { get; set; }
        public int ApartmentTypeId { get; set; }
        public int ApartmentNumber { get; set; }
        public int FloorNumber { get; set; }
    }
}
