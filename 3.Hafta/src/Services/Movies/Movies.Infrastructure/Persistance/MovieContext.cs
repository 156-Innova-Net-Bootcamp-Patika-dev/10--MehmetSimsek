using Microsoft.EntityFrameworkCore;
using Movies.Domain.Common;
using Movies.Domain.Entities;
using Movies.Domain.Entities.IntermediateTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Persistance
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<Director> Directors{ get; set; }

    }
}
