using Movies.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Entities
{
    public class Movie : EntityBase
    {
        public string Title { get; set; }
        public int DirectorId { get; set; }
        public int ReleaseYear { get; set; }
        public double Rating { get; set; }
       
    }
}
