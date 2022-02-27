using Management.Domain.Entites.Messages;
using Management.Domain.Entities.Invoices;
using Management.Domain.Entities.Residents;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Entities.Authentications
{
    public class User : IdentityUser<int>
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Resident Resident { get; set; }
        public Payment Payment { get; set; }

        public virtual ICollection<Message> Sender { get; set; }
        public virtual ICollection<Message> Reciever { get; set; }

    }
}
