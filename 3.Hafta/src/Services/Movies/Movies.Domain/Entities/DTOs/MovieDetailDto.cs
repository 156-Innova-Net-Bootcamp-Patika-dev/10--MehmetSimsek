using Movies.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Entities.DTOs
{
    public class MovieDetailDto : EntityBase
    {
        public string MovieName { get; set; }
        public int GenreId { get; set; }
        public int ReleaseYear { get; set; }
        public double Rating { get; set; }
        public string DirectorName { get; set; }

    }
}
