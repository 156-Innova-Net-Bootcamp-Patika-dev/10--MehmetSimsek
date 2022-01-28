using Movies.Domain.Entities.IntermediateTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Contract.Repository
{
    public interface IMovieGenreRepository : IAsyncRepository<MovieGenre>
    {
        /// 
        /// To list movies according to the category
        ///
        
        Task<IEnumerable<MovieGenre>> GetMoviesByGenreId(int genreId);
        /// 
        /// To list categoriy of the movie
        /// 
        Task<IEnumerable<MovieGenre>> GetGenresByMovieId(int movieId);
    }
}
