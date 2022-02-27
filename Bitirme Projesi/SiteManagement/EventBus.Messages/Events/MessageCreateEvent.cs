using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Events
{
    public class MessageCreateEvent : IntegrationBaseEvent
    {
        public int Id { get; set; }
        public string Message { get; set; }
    }
}
