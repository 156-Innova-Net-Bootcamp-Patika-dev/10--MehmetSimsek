using Management.Domain.Entities.Buildings;
using Management.Domain.Entities.Commons;
using Management.Domain.Entities.Invoices;
using Management.Domain.Enums.Invoicecs;
using Management.Domain.Enums.Invoices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Entites.Invoices
{
    public class Bill : EntityBase
    {
        [ForeignKey(nameof(BillTypeEnum))]
        public int BillTypeEnumId { get; set; }
        [ForeignKey(nameof(BillMonthEnum))]
        public int MonthOfBill { get; set; }
        public double BillAmount { get; set; }
        public int ApartmentId { get; set; }
        public bool IsPaid { get; set; }


        public Apartment Apartment;
        public BillMonthEnum BillMonthEnum { get; set; }
        public BillTypeEnum BillTypeEnum { get; set; }
        public Payment Payment { get; set; }
    }
}
