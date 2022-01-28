using Movies.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Entities.IntermediateTables
{
    public class MovieGenre: EntityBase
    {
        // for n to n relationship between movie and genre
        public int MovieId { get; set; }
        public int GenreId { get; set; }

    }
}
