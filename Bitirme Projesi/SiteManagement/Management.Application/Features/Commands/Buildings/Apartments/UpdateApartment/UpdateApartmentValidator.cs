﻿using FluentValidation;
using Management.Domain.Entities.Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Commands.Buildings.Apartments.UpdateApartment
{
    public class UpdateApartmentValidator: AbstractValidator<Apartment>
    {
        public UpdateApartmentValidator()
        {

        }
    }
}
