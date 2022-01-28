using Movies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Contract.Repository
{
    public interface IGenreRepository : IAsyncRepository<Genre>
    {
        /// <summary>
        /// for listing categories of the movie
        /// </summary>
       
        Task<IEnumerable<Genre>> GetGenresByMovieName(string genreName);
    }
}
