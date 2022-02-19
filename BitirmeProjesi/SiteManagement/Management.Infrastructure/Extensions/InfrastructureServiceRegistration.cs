using Management.Application.Contracts.Persistance.Repositories.Buildings;
using Management.Application.Contracts.Persistance.Repositories.Commons;
using Management.Application.Contracts.Persistance.Repositories.Residents;
using Management.Infrastructure.Contracts.Persistance;
using Management.Infrastructure.Contracts.Persistance.Repositories.Buildngs;
using Management.Infrastructure.Contracts.Persistance.Repositories.Commons;
using Management.Infrastructure.Contracts.Persistance.Repositories.Residents;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Infrastructure.Extensions
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString")));

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            #region Residents
            services.AddScoped<IResidentRepository, ResidentRepository>();

            #endregion
            #region Buildings
            services.AddScoped<IApartmentRepository, ApartmentRepository>();
            services.AddScoped<IApartmentTypeRepository, ApartmentTypeRepository>();
            services.AddScoped<IBlockRepository, BlockRepository>();
            #endregion
            return services;
        }
    }
}
