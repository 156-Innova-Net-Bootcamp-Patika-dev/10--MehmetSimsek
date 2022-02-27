using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.Contracts.Persistance.Settings
{
    public class PaymentDbSettings
    {
        public string MongoDbConnectionString;
        public string Database;
    }
}
