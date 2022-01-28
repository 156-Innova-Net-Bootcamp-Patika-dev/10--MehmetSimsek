using Microsoft.EntityFrameworkCore;
using Movies.Application.Contract.Repository;
using Movies.Domain.Entities;
using Movies.Domain.Entities.DTOs;
using Movies.Infrastructure.Contracts.Repository.Common;
using Movies.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Contracts.Repository
{
    public class MovieRepository : RepositoryBase<Movie>, IMovieRepository
    {
        MovieContext _context;
        public MovieRepository(MovieContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }


        public Task<List<MovieDetailDto>> GetMovieDetails()
        {
          

            var result = from m in _context.Movies
                         join d in _context.Directors
                         on m.DirectorId equals d.Id
                         join mg in _context.MovieGenres
                         on m.Id equals mg.MovieId
                        
                         select new MovieDetailDto()
                         {
                             
                             MovieName = m.Title,
                             Rating = m.Rating,
                             ReleaseYear = m.ReleaseYear,
                             DirectorName = d.FirstName + d.LastName,
                             GenreId = mg.GenreId,

                             


                         };

            return result.ToListAsync();

        }
    }
}
