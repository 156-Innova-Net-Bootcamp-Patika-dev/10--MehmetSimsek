using Movies.Domain.Entities;
using Movies.Domain.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Contract.Services
{
    public interface IMovieService
    {
        //UserInterface functions
        Task<Movie> Add(Movie movie);
        Task<Movie> Update(Movie movie);
        Task<Movie> Delete(Movie movie);
        Task<IReadOnlyList<Movie>> GetAll();
        Task<IReadOnlyList<Movie>> GetByName(string name);
        Task<Movie> GetById(int id);
        Task<List<MovieDetailDto>> GetMovieDetails();


    }
}
