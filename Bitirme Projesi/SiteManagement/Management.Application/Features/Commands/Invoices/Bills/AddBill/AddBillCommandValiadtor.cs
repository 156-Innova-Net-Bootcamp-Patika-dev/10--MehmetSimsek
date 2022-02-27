using FluentValidation;
using Management.Domain.Entites.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Commands.Invoices.Bills.AddBill
{
    public class AddBillCommandValiadtor : AbstractValidator<Bill>
    {
        public AddBillCommandValiadtor()
        {

        }
    }
}
