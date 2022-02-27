using Management.Domain.Entities.Authentications;
using Management.Domain.Entities.Commons;
using Management.Domain.Entities.Residents;
using Management.Domain.Enums.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Entites.Messages
{
    public class Message : EntityBase
    {
        public string Text { get; set; }
        public int MessageSeenInfoEnumId{ get; set; }
        [InverseProperty("Sender")]
        public int SenderId { get; set; }
        [InverseProperty("Reciever")]
        public int RecieverId { get; set; }


       public virtual MessageSeenInfoEnum MessageSeenInfoEnum { get; }
        public virtual User MessageSender { get; set; }
        public virtual User MessageReciever { get; set; }
    }
}
