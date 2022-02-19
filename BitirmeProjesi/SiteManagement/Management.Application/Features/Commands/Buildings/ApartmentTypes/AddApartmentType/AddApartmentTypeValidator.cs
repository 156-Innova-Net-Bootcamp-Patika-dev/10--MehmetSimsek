using FluentValidation;
using Management.Domain.Entities.Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Commands.Buildings.ApartmentTypes.AddApartmentType
{
    public class AddApartmentTypeValidator : AbstractValidator<ApartmentType>
    {
        public AddApartmentTypeValidator()
        {

        }
    }
}
