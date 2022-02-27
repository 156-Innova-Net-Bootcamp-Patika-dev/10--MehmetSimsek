using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Models.Invoices
{
    public class PaymentModel
    {
        public string Name { get; set; }
        public int BillId { get; set; }
        public double Amount { get; set; }
    }
}
