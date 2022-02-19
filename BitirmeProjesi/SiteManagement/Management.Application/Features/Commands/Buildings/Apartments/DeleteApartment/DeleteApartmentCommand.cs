using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Commands.Buildings.Apartments.DeleteApartment
{
    public class DeleteApartmentCommand : IRequest
    {
        public int Id { get; set; }

    }
}
