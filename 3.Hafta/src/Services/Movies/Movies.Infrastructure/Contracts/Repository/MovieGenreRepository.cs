using Movies.Application.Contract.Repository;
using Movies.Domain.Entities.IntermediateTables;
using Movies.Infrastructure.Contracts.Repository.Common;
using Movies.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Contracts.Repository
{
    public class MovieGenreRepository: RepositoryBase<MovieGenre>, IMovieGenreRepository
    {
        public MovieGenreRepository(MovieContext dbContext ) : base( dbContext )
        {

        }

        public Task<IEnumerable<MovieGenre>> GetGenresByMovieId(int movieId)
        {
            // for categories of movie
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MovieGenre>> GetMoviesByGenreId(int genreId)
        {
            //movies according to category
            throw new NotImplementedException();
        }
    }
}
