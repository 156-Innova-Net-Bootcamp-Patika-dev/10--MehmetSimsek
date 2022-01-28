using AutoMapper;
using Movies.Application.Contract.Repository;
using Movies.Application.Contract.Services;
using Movies.Domain.Entities;
using Movies.Domain.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Contracts.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        //private readonly IMapper _mapper;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository ?? throw new ArgumentNullException(nameof(movieRepository));
           // _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Movie> Add(Movie movie)
        {
            return await _movieRepository.AddAsync(movie);
        }

        public async Task<Movie> Delete(Movie movie)
        {
            return await _movieRepository.DeleteAsync(movie);
        }

        public async Task<IReadOnlyList<Movie>> GetAll()
        {
            return await _movieRepository.GetAllAsync();
        }

        public async Task<Movie> GetById(int id)
        {
            return await _movieRepository.GetByIdAsync(id);
        }

        public async Task<IReadOnlyList<Movie>> GetByName(string name)
        {
            return await _movieRepository.GetAsync(m => m.Title.Contains(name));
        }

        public Task<List<MovieDetailDto>> GetMovieDetails()
        {
            return _movieRepository.GetMovieDetails();
            
        }

        public async Task<Movie> Update(Movie movie)
        {
            return await _movieRepository.UpdateAsync(movie);
        }
    }
}
