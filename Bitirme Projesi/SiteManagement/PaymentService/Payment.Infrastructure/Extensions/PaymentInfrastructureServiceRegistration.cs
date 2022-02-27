using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Payment.Application.Contracts.Persistance.Repositories.Commons;
using Payment.Application.Contracts.Persistance.Repositories.Payments;
using Payment.Infrastructure.Contracts.Persistance.Commons;
using Payment.Infrastructure.Contracts.Persistance.Payments;
using Payment.Infrastructure.Contracts.Persistance.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.Extensions
{
    public static class PaymentInfrastructureServiceRegistration
    {
       
        public static IServiceCollection AddInfrastructureMongoService(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<PaymentDbSettings>(options =>
            {
                options.MongoDbConnectionString = configuration.GetSection("MongoDbConnection:MongoDbConnectionString").Value;
                options.Database = configuration.GetSection("MongoDbConnection:Database").Value;
            });
            services.AddScoped(typeof(IMongoRepositoryBase<>), typeof(MongoRepositoryBase<>));
            services.AddScoped<ICreditCardRepository, CreditCardRepository>();
            

            return services;
        }



    }
}
