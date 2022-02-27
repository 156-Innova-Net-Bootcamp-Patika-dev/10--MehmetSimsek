using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Models.Messages
{
    public class MessageModel
    {
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public string Text { get; set; }
        public string MessageInfo { get; set; }
    }
}
