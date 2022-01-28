using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Movies.Application.Contract.Repository;
using Movies.Application.Contract.Services;
using Movies.Infrastructure.Contracts.Repository;
using Movies.Infrastructure.Contracts.Repository.Common;
using Movies.Infrastructure.Contracts.Services;
using Movies.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Infrastructure
{
    public static class InfrastructureServiceRegistiration
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MovieContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("MoviesConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IMovieGenreRepository, MovieGenreRepository>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IDirectorService, DirectorService>();
            services.AddScoped<IDirectorRepository, DirectorRepository>();






            return services;


        }
    }
}
