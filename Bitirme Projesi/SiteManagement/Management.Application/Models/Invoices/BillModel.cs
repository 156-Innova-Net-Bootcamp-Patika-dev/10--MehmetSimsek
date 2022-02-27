using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Models.Invoices
{
    public class BillModel
    {
        public int BillTypeId { get; set; }
        public int MonthofBill { get; set; }
        public double BillAmount { get; set; }
        public int ApartmentNumber { get; set; }
        public string BlockName { get; set; }
        public bool IsPaid { get; set; }

    }
}
