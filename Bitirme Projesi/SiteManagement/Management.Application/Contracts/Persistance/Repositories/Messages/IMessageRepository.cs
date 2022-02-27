using Management.Application.Contracts.Persistance.Repositories.Commons;
using Management.Domain.Entites.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Contracts.Persistance.Repositories.Messages
{
    public interface IMessageRepository : IRepositoryBase<Message>
    {

    }
}
