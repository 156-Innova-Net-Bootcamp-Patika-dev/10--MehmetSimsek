using Movies.Application.Contract.Repository;
using Movies.Application.Contract.Services;
using Movies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Contracts.Services
{
    public class GenreService : IGenreService
    {
        IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<Genre> Add(Genre genre)
        {
            return await _genreRepository.AddAsync(genre);
        }

        public async Task<Genre> Delete(Genre genre)
        {
            return await _genreRepository.DeleteAsync(genre);
        }

        public async Task<IReadOnlyList<Genre>> GetAll()
        {
            return await _genreRepository.GetAllAsync();
        }

        public async Task<Genre> GetById(int id)
        {
            return await _genreRepository.GetByIdAsync(id);
        }

        public async Task<IReadOnlyList<Genre>> GetByName(string name)
        {
           return await _genreRepository.GetAsync(g=>g.Name.Contains(name));
        }

        public async Task<Genre> Update(Genre genre)
        {
            return await _genreRepository.UpdateAsync(genre);
        }
    }
}
