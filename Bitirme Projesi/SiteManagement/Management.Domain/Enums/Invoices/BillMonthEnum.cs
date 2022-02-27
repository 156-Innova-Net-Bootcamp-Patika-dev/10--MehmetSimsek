using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Enums.Invoices
{
    [Flags]
    public enum BillMonthEnum
    {
        [Display]
        January = 1,
        [Display]
        February = 2,
        [Display]
        March = 3,
        [Display]
        April = 4,
        [Display]
        May = 5,
        [Display]
        June = 6,
        [Display]
        July = 7,
        [Display]
        August = 8,
        [Display]
        September = 9,
        [Display]
        October = 10,
        [Display]
        November = 11,
        [Display]
        December = 12,
    }
   
}

