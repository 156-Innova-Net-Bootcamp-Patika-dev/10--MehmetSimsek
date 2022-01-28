using Movies.Application.Contract.Repository;
using Movies.Application.Contract.Services;
using Movies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Contracts.Services
{
    public class DirectorService : IDirectorService
    {
        IDirectorRepository _directorRepository;
            public DirectorService(IDirectorRepository directorRepository)
            {
                _directorRepository = directorRepository;
            }

            public async Task<Director> Add(Director director)
            {
                return await _directorRepository.AddAsync(director);
            }

            public async Task<Director> Delete(Director director)
            {
                return await _directorRepository.DeleteAsync(director);
            }

            public async Task<IReadOnlyList<Director>> GetAll()
            {
                return await _directorRepository.GetAllAsync();
            }

            public async Task<Director> GetById(int id)
            {
                return await _directorRepository.GetByIdAsync(id);
            }

            public async Task<IReadOnlyList<Director>> GetByName(string name)
            {
                return await _directorRepository.GetAsync(g => g.FirstName.Contains(name) || g.LastName.Contains(name));
            }

            public async Task<Director> Update(Director director)
            {
                return await _directorRepository.UpdateAsync(director);
            }
        }
    }

