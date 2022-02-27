using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Payment.Domain.Entities.CreditCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.Contracts.Persistance.Settings
{
    public class PaymentDbContext : DbContext
    {
        private readonly IMongoDatabase _database;

        public PaymentDbContext(IOptions<PaymentDbSettings> settings) 
        {
            // 
            ///<summary>
            ///database connection process
            ///to reach the information in appsettings by using connection string and database names.
            ///</summary>
            ///
            var client = new MongoClient(settings.Value.MongoDbConnectionString);
            _database = client.GetDatabase(settings.Value.Database);
         
           
        }

        public IMongoCollection<T> GetCollection<T>()
        {
            return _database.GetCollection<T>((typeof(T).Name.Trim()));
        }
        public IMongoDatabase GetDatabase()
        {
            return _database;
        }
        public DbSet<CreditCard> CreditCard { get; set; }

    }
}
