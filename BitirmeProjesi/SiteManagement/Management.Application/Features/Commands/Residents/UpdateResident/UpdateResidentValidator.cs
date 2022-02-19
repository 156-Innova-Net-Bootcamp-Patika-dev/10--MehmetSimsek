using FluentValidation;
using Management.Domain.Entities.Residents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Commands.Residents.UpdateResident
{
    public class UpdateResidentValidator : AbstractValidator<Resident>
    {
        public UpdateResidentValidator()
        {
            
        }
    }
}
