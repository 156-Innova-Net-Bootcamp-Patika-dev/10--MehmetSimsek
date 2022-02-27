using Management.Application.Contracts.Persistance.Repositories.Messages;
using Management.Domain.Entites.Messages;
using Management.Infrastructure.Contracts.Persistance.Repositories.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Infrastructure.Contracts.Persistance.Repositories.Messages
{
    public class MessageRepository : RepositoryBase<Message>, IMessageRepository
    {
        public MessageRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
