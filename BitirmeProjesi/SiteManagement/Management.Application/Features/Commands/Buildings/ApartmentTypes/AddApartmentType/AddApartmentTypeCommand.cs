using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Commands.Buildings.ApartmentTypes.AddApartmentType
{
    public class AddApartmentTypeCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
