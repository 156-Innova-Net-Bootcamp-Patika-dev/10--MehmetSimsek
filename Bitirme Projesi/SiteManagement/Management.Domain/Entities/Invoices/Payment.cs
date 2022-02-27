using Management.Domain.Entites.Invoices;
using Management.Domain.Entities.Authentications;
using Management.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Entities.Invoices
{
    public class Payment : EntityBase
    {
        public int UserId { get; set; }
        public int BillId { get; set; }
        public double Amount { get; set; }

        public User User { get; set; }
        public Bill Bill { get; set; }
    }
}
