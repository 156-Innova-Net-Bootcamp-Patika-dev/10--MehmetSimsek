using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Events
{
    public class IntegrationBaseEvent
    {
        public IntegrationBaseEvent()
        {

            SendedTime = DateTime.Now;
        }
        public IntegrationBaseEvent(int id, DateTime sendedTime)
        {
            Id = id;
            SendedTime = sendedTime;
        }

        public int Id { get; set; }
        public DateTime SendedTime { get; set; }
    }
}
