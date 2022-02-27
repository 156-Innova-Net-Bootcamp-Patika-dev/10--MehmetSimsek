using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Events.Payments
{
    public class PaymentCreateEvent 
    {
        public double PaymentAmount { get; set; }

    }
}
