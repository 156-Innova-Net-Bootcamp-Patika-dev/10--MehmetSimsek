using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Models
{
    public class InpaymentModel
    {
        public int UserId { get; set; }
        public int BillId { get; set; }
        public string CardNumber { get; set; }
        public string CardPassword { get; set; }
        public double Amount { get; set; }

    }
}
