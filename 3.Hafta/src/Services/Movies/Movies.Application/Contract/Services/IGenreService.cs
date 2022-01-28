using Movies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Contract.Services
{
    public interface IGenreService
    {
        Task<Genre> Add(Genre genre);
        Task<Genre> Update(Genre genre);
        Task<Genre> Delete(Genre genre);
        Task<IReadOnlyList<Genre>> GetAll();
        Task<IReadOnlyList<Genre>> GetByName(string name);
        Task<Genre> GetById(int id);
    }
}
