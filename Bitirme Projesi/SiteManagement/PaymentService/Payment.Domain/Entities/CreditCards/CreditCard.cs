using Payment.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Entities.CreditCards
{
    public class CreditCard : EntityBase
    {
        public int UserId { get; set; }
        public string CardNumber { get; set; }
        public string CardPassword { get; set; }
        public double Balance { get; set; }

    }
}
