using Movies.Application.Contract.Repository;
using Movies.Domain.Entities;
using Movies.Infrastructure.Contracts.Repository.Common;
using Movies.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Contracts.Repository
{
    public class DirectorRepository : RepositoryBase<Director>, IDirectorRepository
    {
        public DirectorRepository(MovieContext movieContext) : base(movieContext)
        {

        }
    }
}
