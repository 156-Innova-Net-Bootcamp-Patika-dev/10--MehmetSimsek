using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Application.Models.Payments
{
    public class InpaymentModel
    {
        public int BillId { get; set; }
        public double BillAmount { get; set; }
    }
}
