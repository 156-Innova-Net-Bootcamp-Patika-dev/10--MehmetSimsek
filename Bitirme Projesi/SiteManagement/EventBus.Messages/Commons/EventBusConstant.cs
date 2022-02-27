using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Commons
{
    public static class EventBusConstants
    {
        #region Messages
        public const string MessageCreateQueue = "messagecreatequeue";
        public const string MessageSeenQueue = "messageseenqueue";
        #endregion

        #region Payments
        public const string PaymentCreateQueue = "paymentcreatequeue";
        //public const string PaymentSendQueue = "paymentsendqueue";

        #endregion
    }
}
