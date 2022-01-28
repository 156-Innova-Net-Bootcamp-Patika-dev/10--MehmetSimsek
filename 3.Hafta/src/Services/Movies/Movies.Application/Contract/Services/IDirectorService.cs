using Movies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Contract.Services
{
    public interface IDirectorService
    {
        Task<Director> Add(Director director);
        Task<Director> Update(Director director);
        Task<Director> Delete(Director director);
        Task<IReadOnlyList<Director>> GetAll();
        Task<IReadOnlyList<Director>> GetByName(string name);
        Task<Director> GetById(int id);
        
    }
}
