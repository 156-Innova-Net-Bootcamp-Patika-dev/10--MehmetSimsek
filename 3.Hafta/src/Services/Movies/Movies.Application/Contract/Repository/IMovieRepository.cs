using Movies.Domain.Entities;
using Movies.Domain.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Contract.Repository
{
    public interface IMovieRepository: IAsyncRepository<Movie>
    {
        /// kategorisine göre film getirme metodudur.
        /// 
       
        Task<List<MovieDetailDto>> GetMovieDetails();
        
    }
}
