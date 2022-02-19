using FluentValidation;
using Management.Domain.Entities.Residents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Commands.Residents.AddResident
{
    public class AddResidentValidator : AbstractValidator<Resident>
    {
        public AddResidentValidator()
        {

            #region Required
            RuleFor(r => r.Name).NotEmpty().WithMessage("{Name} is required! ");
            RuleFor(r => r.LastName).NotEmpty().WithMessage("{LastName} is required! ");
            RuleFor(r => r.NationalIdentificationNo).NotEmpty()
                .WithMessage("{NationalIdentificationNo} is required! ");
            RuleFor(r => r.Email).Must(IncludeDomain).WithMessage("{Email} has include '@' and '.com' ."); ;
            RuleFor(r => r.Email).NotEmpty().WithMessage("{Email} is required! ");
            RuleFor(r => r.PhoneNumber).NotEmpty().WithMessage("{PhoneNumber} is required!");
            #endregion

            #region Neccesity
            ///<example>
            ///An Email has include domain area like "@gmail.com", "@icloud.com"
            ///</example>
            RuleFor(r => r.Email).Must(IncludeDomain);
            #endregion
        }

        public bool IncludeDomain(string domain)
        {
            var result = domain.Contains("@");
            var checkedIfDotComExist = domain.Contains(".com");
            if (result && checkedIfDotComExist)
                return true;
            return false;
        }
    }
}
